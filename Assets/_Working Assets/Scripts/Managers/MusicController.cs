using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AnimationCurve _volumeCurve;
    [SerializeField] private AudioSource _audioSource;

    // Update is called once per frame
    void Update ()
    {
        if (_audioSource == null) return;

        _audioSource.volume = _volumeCurve.Evaluate(GameManager.Instance.NormalizedTime);
    }
}
