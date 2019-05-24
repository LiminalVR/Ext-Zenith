using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    public static AudioFader Instance;

    private Coroutine m_audioFadeRoutine;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        FadeToVolume(0, 0);
        FadeToVolume(0.8f, 10);
    }

    public void FadeToVolume(float targetVolume, float fadeTime = 1f)
    {
        if (m_audioFadeRoutine != null)
        {
            StopCoroutine(m_audioFadeRoutine);
        }

        m_audioFadeRoutine = StartCoroutine(FadeEffect(targetVolume, fadeTime));
    }

    private IEnumerator FadeEffect(float targetVolume, float fadeTime = 1f)
    {
        var elapsedTime = 0f;
        var startVol = AudioListener.volume;

        while (elapsedTime <= fadeTime)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(startVol, targetVolume, elapsedTime / fadeTime);
            yield return new WaitForEndOfFrame();
        }

        m_audioFadeRoutine = null;
    }
}
