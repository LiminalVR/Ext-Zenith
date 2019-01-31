using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private Transform m_StartPoint;
    [SerializeField] private Transform m_EndPoint;
    [SerializeField] private Transform m_UIPanel;

    private Coroutine m_AnimRoutine;
    // Use this for initialization
    void Start ()
    {
        Invoke("LateStart", 0.5f);
    }

    private void LateStart()
    {
        GameManager.Instance.PlanetWasSelected += AnimateIn;
        GameManager.Instance.UIWasHidden += AnimateOut;
    }

    private void AnimateIn()
    {
        if (m_AnimRoutine != null)
        {
            StopCoroutine(m_AnimRoutine);
        }

        m_AnimRoutine = StartCoroutine(MoveTowards(m_EndPoint));
    }
    

    private void AnimateOut()
    {
        if (m_AnimRoutine != null)
        {
            StopCoroutine(m_AnimRoutine);
        }

        m_AnimRoutine = StartCoroutine(MoveTowards(m_StartPoint));
    }

    private IEnumerator MoveTowards(Transform target)
    {
        float dist = 1;
        while (dist > 0)
        {
            dist = Vector3.Distance(m_UIPanel.position, target.position);
            m_UIPanel.localPosition =
                Vector3.MoveTowards(m_UIPanel.localPosition, target.localPosition, m_MoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        m_AnimRoutine = null;
    }
}
