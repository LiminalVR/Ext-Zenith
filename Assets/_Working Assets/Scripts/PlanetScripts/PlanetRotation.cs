using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float BaseRotationSpeed;
    public float RotSpeed;
    public float Dampening;

    [SerializeField] private AnimationCurve _speedMultiplierCurve;

    private float m_SlowDownTime=0;


    // Update is called once per frame
    void Update()
    {
        RotSpeed = BaseRotationSpeed * _speedMultiplierCurve.Evaluate(GameManager.Instance.NormalizedTime);
        transform.Rotate((Vector3.up * RotSpeed) * (Time.deltaTime * Dampening), Space.Self);
    }
}

