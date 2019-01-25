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

    private float m_AcceleratonTime = 0;

    private Coroutine m_SizeRoutine;

    private bool m_IsInteractive;

// Use this for initialization
    void Start ()
    {
        BaseScale = transform.localScale;
    }

    public void LerpToSize(Vector3 targetSize)
    {
        if (m_SizeRoutine != null)
        {
            StopCoroutine(m_SizeRoutine);
        }

        m_SizeRoutine = StartCoroutine(SizeLerp(targetSize));
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
        if (m_IsInteractive == false) return;

        base.OnPointerClick(eventData);
        OnClickedAudio.Play(0);
        GameManager.Instance.SelectPlanet(gameObject);
        GameManager.Instance.AcceptChanges();
    }

    public void SetInteractive(bool newState)
    {
        m_IsInteractive = newState;
    }

    public void Init()
    {
        StartCoroutine(AccelerateRoutine());
    }

    private IEnumerator AccelerateRoutine()
    {
        while (m_AcceleratonTime < 3f)
        {
            yield return new WaitForEndOfFrame();
            m_AcceleratonTime += Time.deltaTime;
            RotScript.baseRotationSpeed = Mathf.Lerp(0, 10, m_AcceleratonTime/3f);
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
