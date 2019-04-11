using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUIController : MonoBehaviour
{
    [SerializeField] private float m_TimeToWaitBeforeDisable;
    [SerializeField] private List<Transform> m_TargetPoints;
    [SerializeField] private AnimationCurve m_SizeCurve;

    private Coroutine m_DisableRoutine;
    private float m_UpTime;
    private Coroutine m_SizeLerp;
    private bool m_CachedIsShowing = false;

    public void Init()
    {
        GameManager.Instance.PlanetStatWasChanged += ResetTimer;
        GetComponentInChildren<SizeSliderController>(includeInactive: true).UpdateValues();
        GetComponentInChildren<MaterialSliderController>(includeInactive: true).UpdateValues();

        if (m_DisableRoutine != null)
        {
            StopCoroutine(m_DisableRoutine);
        }
        m_DisableRoutine = StartCoroutine(DisableTimer());
    }

    public void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        var closestPoint = m_TargetPoints[0];
        var greatestValue = 0f;

        foreach (var point in m_TargetPoints)
        {
            var forward = Camera.main.transform.forward;
            var toOther = point.position - Camera.main.transform.position;

            var dotVal = Vector3.Dot(forward, toOther);

            if (!(dotVal > greatestValue)) continue;

            greatestValue = dotVal;
            closestPoint = point;
        }

        transform.SetParent(closestPoint);

        transform.forward = -closestPoint.forward;
        transform.localPosition = Vector3.zero;
    }

    void OnEnable()
    {
        if (m_DisableRoutine == null)
        {
            m_DisableRoutine = StartCoroutine(DisableTimer());
        }
    }

    private void ResetTimer()
    {
        m_UpTime = 0;
    }

    private IEnumerator DisableTimer()
    {
        while (m_UpTime < m_TimeToWaitBeforeDisable)
        {
            m_UpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        m_UpTime = 0;
        m_DisableRoutine = null;

        ShowHide(false);
    }

    public void ShowHide(bool isShowing)
    {
        if (m_SizeLerp != null) return;

        m_SizeLerp = StartCoroutine(ShowHideRoutine(isShowing));
    }

    private IEnumerator ShowHideRoutine(bool isShowing)
    {
        var speed = -1f;
        var positionOnCurve = 1f;
        var elapsedTime = 0f;
        var maxTime = m_SizeCurve.keys[m_SizeCurve.keys.Length - 1].time;

        if (isShowing)
        {
            speed = 1f;
            positionOnCurve = 0;

            if (Mathf.Approximately(transform.localScale.x, Vector3.one.x * m_SizeCurve.Evaluate(maxTime)))
            {
                if (m_DisableRoutine == null)
                {
                    m_DisableRoutine = StartCoroutine(DisableTimer());
                }
                yield break;
            }
        }

        while (elapsedTime < maxTime)
        {
            
            positionOnCurve += speed * Time.deltaTime;
            elapsedTime += Time.deltaTime;

            //done to prevent visual bugs when swapping between planets when UI changing size
            while (!Mathf.Approximately(transform.localScale.x, Vector3.one.x * m_SizeCurve.Evaluate(positionOnCurve)))
            {
                transform.localScale = Vector3.one * m_SizeCurve.Evaluate(positionOnCurve);
                yield return new WaitForEndOfFrame();
            }
            print(elapsedTime +"   "+isShowing);

            yield return new WaitForEndOfFrame();
        }

        m_SizeLerp = null;

        if (!isShowing)
        {
            gameObject.SetActive(false);
        }
        else if(m_DisableRoutine == null)
        {
            m_DisableRoutine = StartCoroutine(DisableTimer());
        }
    }
}
