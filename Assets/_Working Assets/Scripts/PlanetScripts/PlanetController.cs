using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetController : DiegeticButton
{
    public PlanetRotation RotScript;
    public float CurSpeed;

    public AudioSource OnClickedAudio;

    public Vector3 BaseScale;

    public int SizeIndex;
    public int MaterialIndex;
    public float SizeLerpTime;

    private float acceleratonTime = 0;

    private Coroutine SizeRoutine;

// Use this for initialization
    void Start ()
    {
        BaseScale = transform.localScale;
    }

    public void LerpToSize(Vector3 targetSize)
    {
        if (SizeRoutine != null)
        {
            StopCoroutine(SizeRoutine);
        }

        SizeRoutine = StartCoroutine(SizeLerp(targetSize));
    }

    private IEnumerator SizeLerp(Vector3 targetSize)
    {
        var elapsedTime = 0f;
        var startSize = transform.localScale;
        while (elapsedTime < SizeLerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startSize, targetSize, elapsedTime / SizeLerpTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetSize;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        OnClickedAudio.Play(0);
        GameManager.Instance.SelectPlanet(gameObject);
        GameManager.Instance.AcceptChanges();
    }

    public void Init()
    {
        StartCoroutine(AccelerateRoutine());
    }

    private IEnumerator AccelerateRoutine()
    {
        while (acceleratonTime < 3f)
        {
            yield return new WaitForEndOfFrame();
            acceleratonTime += Time.deltaTime;
            RotScript.baseRotationSpeed = Mathf.Lerp(0, 10, acceleratonTime/3f);
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
}
