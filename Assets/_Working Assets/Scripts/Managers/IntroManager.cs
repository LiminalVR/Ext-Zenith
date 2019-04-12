using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public List<PlanetTiming> PlanetTimings;
    public CanvasGroup IntroCanvas;

    [System.Serializable]
    public class PlanetTiming
    {
        public PlanetController Planet;
        public float delay;
    }

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

        var textFadeVal = 0f;

        while (textFadeVal < 1f)
        {
            textFadeVal += Time.deltaTime;
            IntroCanvas.alpha = textFadeVal;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(4f);
        while (textFadeVal > 0f)
        {
            textFadeVal -= Time.deltaTime;
            IntroCanvas.alpha = textFadeVal;
            yield return new WaitForEndOfFrame();
        }

        FaderController.Instance.SetRenderOrder(3000);

        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            yield return new WaitForSeconds(2f);
            GameManager.Instance.SetPlanetScale(planet.SizeIndex, 1,planet.gameObject);  
        }
        yield return new WaitForSeconds(2f);
        FaderController.Instance.FadeToColor(2, new Color(0, 0, 0, 0));

        GameManager.Instance.CurState = GameManager.SystemState.Playing;
        foreach (var planet in GameManager.Instance.AllPlanetControllers)
        {
            planet.SetInteractive(true);
        }

        foreach (var item in PlanetTimings)
        {
            yield return new WaitForSeconds(item.delay);
            item.Planet.Init();
            
        }
    }
}
