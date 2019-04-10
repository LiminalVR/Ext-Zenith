using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AnimationCurve _volumeCurve;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool isEnding;

    private bool m_updateLoop;

    // Update is called once per frame
    void Update ()
    {
        if (_audioSource == null || isEnding) return;

        _audioSource.volume = _volumeCurve.Evaluate(GameManager.Instance.NormalizedTime);
    }

    public void End(float fadeTime = 2f)
    {
        isEnding = true;
        StartCoroutine(FadeSound(fadeTime));
    }

    private IEnumerator FadeSound(float fadeTime)
    {
        var elapsedTime = 0f;
        var starVal = _audioSource.volume;
        while (elapsedTime < fadeTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(0.1f, 0, elapsedTime / fadeTime);
        }
    }


}
