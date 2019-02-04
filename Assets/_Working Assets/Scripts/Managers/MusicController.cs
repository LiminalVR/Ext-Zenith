using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AnimationCurve m_VolumeCurve;
    [SerializeField] private AudioSource m_AudioSource;

    // Update is called once per frame
    void Update ()
    {
        if (m_AudioSource == null) return;

        m_AudioSource.volume = m_VolumeCurve.Evaluate(GameManager.Instance.NormalizedTime);
    }
}
