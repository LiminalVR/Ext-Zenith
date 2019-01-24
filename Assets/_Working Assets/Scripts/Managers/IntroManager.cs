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
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.HeartMan.Init();

        yield return new WaitForSeconds(2f);
        FaderController.Instance.ChangeSize(new Vector3(10000, 10000, 10000), 12f);
       
        yield return new WaitForSeconds(8f);
        FaderController.Instance.FadeToColor(2, new Color(0, 0, 0, 0));

        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            yield return new WaitForSeconds(5f);
            planet.Init();
        }
    }
}
