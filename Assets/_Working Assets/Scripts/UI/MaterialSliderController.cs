using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSliderController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> m_PooledAudioSources;

    private void OnEnable()
    {
        UpdateValues();
    }

    public void UpdateValues()
    {
        GetComponent<Slider>().value = GameManager.Instance.SelectedPlanet.GetComponent<PlanetController>().MaterialIndex;
    }

    public void SetPlanetMaterial(float sliderValue)
    {
        if (GameManager.Instance.PlanetStatWasChanged != null)
        {
            GameManager.Instance.PlanetStatWasChanged.Invoke();
        }

        foreach (var AS in m_PooledAudioSources)
        {
            if (AS.isPlaying) continue;
            AS.Play();
        }

        var intVal = Mathf.FloorToInt(sliderValue);

        GameManager.Instance.SetPlanetMaterial(intVal);
    }
}
