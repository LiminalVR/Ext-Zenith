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

        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            planet.LerpToSize(Vector3.zero);   
        }


        yield return new WaitForSeconds(2f);
        FaderController.Instance.ChangeSize(new Vector3(10000, 10000, 10000), 0.1f);

        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            yield return new WaitForSeconds(2f);
            GameManager.Instance.SelectedPlanet = planet.gameObject;
            GameManager.Instance.SetPlanetScale(planet.SizeIndex);  
        }
        yield return new WaitForSeconds(2f);
        FaderController.Instance.FadeToColor(2, new Color(0, 0, 0, 0));

        GameManager.Instance.CurState = GameManager.SystemState.Playing;
        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            planet.SetInteractive(true);
        }

        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            yield return new WaitForSeconds(5f);
            planet.Init();
        }
    }
}
