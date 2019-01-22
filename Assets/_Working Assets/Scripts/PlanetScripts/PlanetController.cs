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

    private float acceleratonTime = 0;

// Use this for initialization
    void Start ()
    {
        BaseScale = transform.localScale;
    }

    private void Update()
    {
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        OnClickedAudio.Play(0);
        GameManager.Instance.SelectPlanet(gameObject);
    }

    public void PlanetDataSet()
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
