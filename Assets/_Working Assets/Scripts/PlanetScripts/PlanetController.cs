using System.Collections;
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
    private Coroutine m_AccellRoutine;

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
        var _elapsedTime = 0f;
        var _startSize = transform.localScale;
        var _multiplier = ScaleMultiplierCurve.Evaluate(SizeIndex);

        while (_elapsedTime < lerpTime)
        {
            _elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_startSize, targetSize * _multiplier, _elapsedTime / lerpTime);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = targetSize * _multiplier;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        GameManager.Instance.SelectPlanet(gameObject);
        GameManager.Instance.SetPlanetMaterial(MaterialIndex);
    }

    public void SetInteractive(bool newState)
    {
        m_IsInteractive = newState;
    }

    public void Init()
    {
        if (m_AccellRoutine != null)
            return;
        
        m_AccellRoutine = StartCoroutine(AccelerateRoutine());
    }

    private IEnumerator AccelerateRoutine()
    {
        while (m_AcceleratonTime < 3f)
        {
            yield return new WaitForEndOfFrame();
            m_AcceleratonTime += Time.deltaTime;
            RotScript.BaseRotationSpeed = Mathf.Lerp(0, StartSpeed, m_AcceleratonTime/3f);
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
