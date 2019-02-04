using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetController : MonoBehaviour
{

    [SerializeField] private AnimationCurve m_DividerCurve;
    private Coroutine m_SizeRoutine;

    public void LerpToSize(Vector3 targetSize, int index, float lerpTime = 1)
    {
        if (!gameObject.activeSelf) return;

        if (m_SizeRoutine != null)
        {
            StopCoroutine(m_SizeRoutine);
        }

        m_SizeRoutine = StartCoroutine(SizeLerp(targetSize, index, lerpTime));
    }

    private IEnumerator SizeLerp(Vector3 targetSize, int index, float lerpTime = 1)
    {
        var elapsedTime = 0f;
        var startSize = transform.localScale;

        targetSize /= m_DividerCurve.Evaluate(index);

        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startSize, targetSize, elapsedTime / lerpTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetSize;
    }
}
