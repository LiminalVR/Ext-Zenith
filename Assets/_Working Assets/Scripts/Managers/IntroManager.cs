using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

	// Use this for initialization
	public void Init ()
    {
        StartCoroutine(ScriptRoutine());
    }

    private IEnumerator ScriptRoutine()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.HeartMan.Init();
        yield return new WaitForSeconds(10f);
        FaderController.Instance.FadeToColor(2, new Color(0, 0, 0, 0));
    }
}
