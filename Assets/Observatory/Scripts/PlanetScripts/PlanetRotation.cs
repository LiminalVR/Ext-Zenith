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
        //if more than 20 seconds remain in the experience, work off the curve
        if ((GameManager.Instance.NormalizedTime * GameManager.Instance.ExperienceLength) <
            GameManager.Instance.ExperienceLength - 20f)
        {
            rotSpeed = baseRotationSpeed * m_SpeedMultiplierCurve.Evaluate(GameManager.Instance.NormalizedTime); 
        }
        else
        {
            if (transform.rotation.y > -20 && transform.rotation.y <= 0)
            {
                print(transform.rotation.y + "   " + (0 - transform.rotation.y));
                rotSpeed = Mathf.Lerp(10, 0.1f, (0-transform.rotation.y) / 20);
            }
        }
        transform.Rotate((Vector3.up * rotSpeed) * (Time.deltaTime * dampening), Space.Self);


    }
}

