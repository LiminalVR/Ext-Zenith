using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableUIController : MonoBehaviour
{
    [FormerlySerializedAs("m_TimeToWaitBeforeDisable")]
    [SerializeField] private float _timeToWaitBeforeDisable;
    [FormerlySerializedAs("m_TargetPoints")]
    [SerializeField] private List<Transform> _targetPoints;
    [FormerlySerializedAs("m_GrowthCurve")]
    [SerializeField] private AnimationCurve _growthCurve;
    [FormerlySerializedAs("m_ShrinkCurve")]
    [SerializeField] private AnimationCurve _shrinkCurve;
    [FormerlySerializedAs("m_CurState")]
    [SerializeField] private UIState _curState;
    [SerializeField] private CanvasGroup _CGroup;

    private Coroutine m_DisableRoutine;
    private float m_UpTime;
    private Coroutine m_SizeLerp;
    private bool m_CachedIsShowing = false;

    public enum UIState
    {
        Visible,
        Hidden,
        Showing,
        Hiding,
    };


    public void Init()
    {
        GameManager.Instance.PlanetStatWasChanged += ResetTimer;
        GetComponentInChildren<SizeSliderController>(includeInactive: true).UpdateValues();
        GetComponentInChildren<MaterialSliderController>(includeInactive: true).UpdateValues();

        if (_curState != UIState.Visible) return;

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
        var closestPoint = _targetPoints[0];
        var greatestValue = 0f;

        foreach (var point in _targetPoints)
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

    private void ResetTimer()
    {
        m_UpTime = 0;
    }

    private IEnumerator DisableTimer()
    {
        while (m_UpTime < _timeToWaitBeforeDisable)
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
        var elapsedTime = 0f;
        var targetCurve = _shrinkCurve;
        _curState = UIState.Hiding;

        _CGroup.interactable = false;

        if (isShowing)
        {
            targetCurve = _growthCurve;
            _curState = UIState.Showing;
        }

        var maxTime = targetCurve.keys[_shrinkCurve.keys.Length - 1].time;

        if (Mathf.Approximately(transform.localScale.x, Vector3.one.x * targetCurve.Evaluate(maxTime)))
        {
            elapsedTime = maxTime;
        }

        while (elapsedTime < maxTime)
        {
            elapsedTime += Time.deltaTime;

            //done to prevent visual bugs when swapping between planets when UI changing size
            while (!Mathf.Approximately(transform.localScale.x, Vector3.one.x * targetCurve.Evaluate(elapsedTime)))
            {
                transform.localScale = Vector3.one * targetCurve.Evaluate(elapsedTime);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForEndOfFrame();
        }

        m_SizeLerp = null;

        if (!isShowing)
        {
            _curState = UIState.Hidden;
            gameObject.SetActive(false);
        }
        else
        {
            _curState = UIState.Visible;
            _CGroup.interactable = true;
            if (m_DisableRoutine == null)
            {
                m_DisableRoutine = StartCoroutine(DisableTimer());
            }
        } 
    }
}
