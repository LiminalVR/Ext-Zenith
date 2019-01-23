using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatManager : MonoBehaviour
{
    public delegate void HeartbeatSound();
    public HeartbeatSound Heartbeat;

    [SerializeField] private float m_TimeBetweenHeartbeats;
    [SerializeField] private AnimationCurve m_HeartbeatCurve;
    [SerializeField] private AudioSource m_HeartbeatAS;
    [SerializeField] private float m_VolumeDecreaseSpeed;

    // Use this for initialization
    public void Init ()
    {
        StartCoroutine(HeartbeatRoutine());
    }

    private IEnumerator HeartbeatRoutine()
    {
        while (GameManager.Instance.curState == GameManager.SystemState.Playing)
        {
            PlayHeartbeat();
            yield return new WaitForSeconds(m_TimeBetweenHeartbeats *
                                            m_HeartbeatCurve.Evaluate(GameManager.Instance.NormalizedTime));
        }

        StartCoroutine(FadeHeartbeat());

        while (GameManager.Instance.curState == GameManager.SystemState.Ending)
        {
            PlayHeartbeat();
            yield return new WaitForSeconds(m_TimeBetweenHeartbeats *
                                            m_HeartbeatCurve.Evaluate(GameManager.Instance.NormalizedTime));
        }

        yield return new WaitForEndOfFrame();
    }

    private void PlayHeartbeat()
    {
        if (m_HeartbeatAS == null) return;

        m_HeartbeatAS.Play();

        if (Heartbeat != null)
        {
            Heartbeat.Invoke();
        }
    }

    private IEnumerator FadeHeartbeat()
    {
        while (m_HeartbeatAS.volume>0)
        {
            var newVol = m_HeartbeatAS.volume;
            newVol = Mathf.Clamp(newVol - (m_VolumeDecreaseSpeed * Time.deltaTime), 0.1f, 1);
            m_HeartbeatAS.volume = newVol;
            yield return new WaitForEndOfFrame();
        }
    }
}
