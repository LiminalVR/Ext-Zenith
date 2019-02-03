using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUIController : MonoBehaviour
{
    [SerializeField] private float m_TimeToWaitBeforeDisable;
    [SerializeField] private List<Transform> m_TargetPoints;

    private Coroutine m_DisableRoutine;
    private float m_ElapsedTime;

    void Start()
    {
        GameManager.Instance.PlanetStatWasChanged += ResetTimer;
    }

    public void Init()
    {
        GetComponentInChildren<SizeSliderController>(includeInactive: true).UpdateValues();
        GetComponentInChildren<MaterialSliderController>(includeInactive: true).UpdateValues();

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

        /*

        foreach (var point in m_TargetPoints)
        {
            if (point == closestPoint)
            {
                point.parent.gameObject.SetActive(true);
                continue;
            }

            point.parent.gameObject.SetActive(false);
        }

    */

        transform.SetParent(closestPoint);

        //transform.localEulerAngles = Vector3.zero;
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
        m_ElapsedTime = 0;
    }

    private IEnumerator DisableTimer()
    {
        while (m_ElapsedTime < m_TimeToWaitBeforeDisable)
        {
            m_ElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        m_ElapsedTime = 0;
        m_DisableRoutine = null;
        gameObject.SetActive(false);
    }
}
