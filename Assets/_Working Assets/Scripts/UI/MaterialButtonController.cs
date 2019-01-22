using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialButtonController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> m_PooledAudioSources;

    // Use this for initialization
    void Start()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var go = transform.GetChild(i).gameObject;
            go.GetComponent<Button>().onClick.AddListener(delegate { SetPlanetMaterial(go); });
        }
    }

    private void SetPlanetMaterial(GameObject go)
    {
        foreach (var AS in m_PooledAudioSources)
        {
            if (AS.isPlaying) continue;
            AS.Play();
        }

        var curIndex = 0;
        for (var i = 0; i < go.transform.parent.childCount; i++)
        {
            if (!go.transform.parent.GetChild(i).gameObject.Equals(go)) continue;
            curIndex = i;
            break;
        }
        GameManager.Instance.SetPlanetMaterial(curIndex);
    }
}
