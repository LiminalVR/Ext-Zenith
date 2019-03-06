using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetController : MonoBehaviour
{
    [SerializeField] private AnimationCurve _dividerCurve;
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
        var _elapsedTime = 0f;
        var _startSize = transform.localScale;

        targetSize /= _dividerCurve.Evaluate(index);

        while (_elapsedTime < lerpTime)
        {
            _elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_startSize, targetSize, _elapsedTime / lerpTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetSize;
    }
}
