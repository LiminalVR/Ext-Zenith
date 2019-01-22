using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    public float baseRotationSpeed;
    public float rotSpeed;
    public float dampening;
    [SerializeField] private AnimationCurve m_SpeedMultiplierCurve;

    private float slowDownTime=0;


    // Update is called once per frame
    void Update()
    {
        rotSpeed = baseRotationSpeed * m_SpeedMultiplierCurve.Evaluate(GameManager.Instance.NormalizedTime);
        transform.Rotate((Vector3.up * rotSpeed) * (Time.deltaTime * dampening), Space.Self);


    }
}

