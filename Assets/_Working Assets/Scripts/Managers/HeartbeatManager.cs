﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatManager : MonoBehaviour
{
    public delegate void HeartbeatSound();
    public HeartbeatSound Heartbeat;

    [SerializeField] private List<AudioSource> m_PooledHeartbeatSources;
    [SerializeField] private AnimationCurve m_HeartbeatBPMCurve;
    [SerializeField] private AnimationCurve m_HeartbeatVolumeCurve;
    [SerializeField] private AudioSource m_HeartbeatAS;
    [SerializeField] private float m_VolumeDecreaseSpeed;

    // Use this for initialization
    public void Init ()
    {
        StartCoroutine(HeartbeatRoutine());
    }

    private IEnumerator HeartbeatRoutine()
    {
        while (GameManager.Instance.CurState == GameManager.SystemState.Revealing)
        {
            yield return new WaitForEndOfFrame();
        }

        while (GameManager.Instance.CurState == GameManager.SystemState.Playing || GameManager.Instance.CurState == GameManager.SystemState.Ending)
        {
            PlayHeartbeat();
            yield return new WaitForSeconds(60f/m_HeartbeatBPMCurve.Evaluate(GameManager.Instance.NormalizedTime));
        }

        yield return new WaitForEndOfFrame();
    }

    private void PlayHeartbeat()
    {
        foreach (var HB in m_PooledHeartbeatSources)
        {
            if(HB.isPlaying) continue;

            HB.volume = m_HeartbeatVolumeCurve.Evaluate(GameManager.Instance.NormalizedTime);
            HB.Play();
        }

        if (Heartbeat != null)
        {
            //done as an event so that we can hook up external scripts to  call events.
            Heartbeat.Invoke();
        }
    }
}
