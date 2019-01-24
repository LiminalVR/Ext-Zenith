using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderController : MonoBehaviour
{
    public static FaderController Instance;
    private Material m_ThisMaterial;
    private MeshCollider m_ThisMeshCollider;
    private Coroutine m_FadeRoutine;


    private void Start()
    {
        m_ThisMaterial = GetComponent<MeshRenderer>().material;
        m_ThisMeshCollider = GetComponent<MeshCollider>();

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
        float elapsedTime = 0;
        var startColor = m_ThisMaterial.GetColor("_Color");
        var lerpColor = startColor;

        while (elapsedTime < timeToFade)
        { 
            elapsedTime += Time.deltaTime;
            lerpColor = Color.Lerp(startColor, targetColor, elapsedTime / timeToFade);
            m_ThisMaterial.SetColor("_Color", lerpColor);
            yield return new WaitForEndOfFrame();
        }

        var transColor = new Color(0,0,0,0);

        m_ThisMeshCollider.enabled = !targetColor.Equals(transColor);
    }

    private IEnumerator GrowToSize(Vector3 targetSize,float growthTime)
    {
        var elapsedTime = 0f;
        var initialSize = transform.localScale;
        while (elapsedTime < growthTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialSize, targetSize, elapsedTime / growthTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
