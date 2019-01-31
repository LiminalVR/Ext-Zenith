using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetController : MonoBehaviour {

    private Coroutine m_SizeRoutine;

    public void LerpToSize(Vector3 targetSize, float lerpTime = 1)
    {
        if (m_SizeRoutine != null)
        {
            StopCoroutine(m_SizeRoutine);
        }

        m_SizeRoutine = StartCoroutine(SizeLerp(targetSize, lerpTime));
    }

    private IEnumerator SizeLerp(Vector3 targetSize, float lerpTime = 1)
    {
        var elapsedTime = 0f;
        var startSize = transform.localScale;

        targetSize /= 4f;

        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startSize, targetSize, elapsedTime / lerpTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetSize;
    }
}
