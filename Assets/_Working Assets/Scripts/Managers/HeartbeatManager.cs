using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatManager : MonoBehaviour
{
    public delegate void HeartbeatSound();
    public HeartbeatSound Heartbeat;

    [SerializeField] private List<AudioSource> _pooledHeartbeatSources;
    [SerializeField] private AnimationCurve _heartbeatBPMCurve;
    [SerializeField] private AnimationCurve _heartbeatVolumeCurve;

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
            yield return new WaitForSeconds(60f/_heartbeatBPMCurve.Evaluate(GameManager.Instance.NormalizedTime));
        }

        yield return new WaitForEndOfFrame();
    }

    private void PlayHeartbeat()
    {
        foreach (var HB in _pooledHeartbeatSources)
        {
            if(HB.isPlaying) continue;

            HB.volume = _heartbeatVolumeCurve.Evaluate(GameManager.Instance.NormalizedTime);
            HB.Play();
        }

        Heartbeat?.Invoke();
    }
}
