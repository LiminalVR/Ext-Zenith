using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatManager : MonoBehaviour
{

	// Use this for initialization
	public void Init ()
    {
        StartCoroutine(HeartbeatRoutine());
    }

    private IEnumerator HeartbeatRoutine()
    {
        yield return new WaitForEndOfFrame();
    }
}
