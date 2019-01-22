using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeButtonController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var go = transform.GetChild(i).gameObject;
            go.GetComponent<Button>().onClick.AddListener(delegate { SetPlanetSize(go); });
        }
	}

    private static void SetPlanetSize(GameObject go)
    {
        var curIndex = 0;
        for (var i = 0; i < go.transform.parent.childCount; i++)
        {
            if (!go.transform.parent.GetChild(i).gameObject.Equals(go)) continue;
            curIndex = i;
            break;
        }
        GameManager.Instance.SetPlanetScale(curIndex);
    }
}
