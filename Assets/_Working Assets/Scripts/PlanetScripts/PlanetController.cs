using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetController : DiegeticButton
{
    public PlanetRotation RotScript;
    public float StartSpeed;

    public AudioSource OnClickedAudio;

    [Tooltip("Hacky code used to ensure we can conrol the relative scales of objects easily.")]
    public AnimationCurve ScaleMultiplierCurve = AnimationCurve.Linear(0, 1, 1, 1);

    public int SizeIndex;
    public int MaterialIndex;

    private float m_AcceleratonTime = 0;

    private Coroutine m_SizeRoutine;

    private bool m_IsInteractive;

    private Coroutine accellRoutine;

// Use this for initialization
    void Start ()
    {
        
    }

    public void LerpToSize(Vector3 targetSize, float lerpTime = 1)
    {
        if (m_SizeRoutine != null)
        {
            StopCoroutine(m_SizeRoutine);
        }

        m_SizeRoutine = StartCoroutine(SizeLerp(targetSize, lerpTime));
    }

    private IEnumerator SizeLerp(Vector3 targetSize, float lerpTime =1)
    {
        var elapsedTime = 0f;
        var startSize = transform.localScale;

        var multiplier = ScaleMultiplierCurve.Evaluate(SizeIndex);
        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startSize, targetSize * multiplier, elapsedTime / lerpTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetSize * multiplier;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (m_IsInteractive == false) return;

        base.OnPointerClick(eventData);
        //OnClickedAudio.Play(0);
        GameManager.Instance.SelectPlanet(gameObject);
        GameManager.Instance.AcceptChanges();
        Init();
    }

    public void SetInteractive(bool newState)
    {
        m_IsInteractive = newState;
    }

    public void Init()
    {
        if (accellRoutine != null) return;
        
        accellRoutine = StartCoroutine(AccelerateRoutine());
    }

    private IEnumerator AccelerateRoutine()
    {
        while (m_AcceleratonTime < 3f)
        {
            yield return new WaitForEndOfFrame();
            m_AcceleratonTime += Time.deltaTime;
            RotScript.baseRotationSpeed = Mathf.Lerp(0, StartSpeed, m_AcceleratonTime/3f);
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
