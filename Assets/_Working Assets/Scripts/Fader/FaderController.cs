using System.Collections;
using UnityEngine;

public class FaderController : MonoBehaviour
{
    public static FaderController Instance;
    private Material m_ThisMaterial;
    private Coroutine m_FadeRoutine;

    private void Start()
    {
        m_ThisMaterial = GetComponent<MeshRenderer>().material;

        Instance = this;
    }

    public void ChangeSize(Vector3 targetSize, float growthTime)
    {
        StartCoroutine(GrowToSize(targetSize, growthTime));
    }

    public void FadeToColor(float timeToFade, Color targetColor)
    {
        if (m_FadeRoutine != null)
        {
            StopCoroutine(m_FadeRoutine);
        }

        m_FadeRoutine = StartCoroutine(Fade(timeToFade, targetColor));
    }

    private IEnumerator Fade(float timeToFade, Color targetColor)
    {
        float _elapsedTime = 0;
        var _startColor = m_ThisMaterial.GetColor("_Color");
        var _lerpColor = _startColor;

        while (_elapsedTime < timeToFade)
        { 
            _elapsedTime += Time.deltaTime;
            _lerpColor = Color.Lerp(_startColor, targetColor, _elapsedTime / timeToFade);
            m_ThisMaterial.SetColor("_Color", _lerpColor);
            yield return new WaitForEndOfFrame();
        }

        var _transColor = new Color(0,0,0,0);
    }

    public void SetRenderOrder(int renderOrder)
    {
        m_ThisMaterial.renderQueue = renderOrder;
    }

    private IEnumerator GrowToSize(Vector3 targetSize,float growthTime)
    {
        var _elapsedTime = 0f;
        var _initialSize = transform.localScale;

        while (_elapsedTime < growthTime)
        {
            _elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_initialSize, targetSize, _elapsedTime / growthTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
