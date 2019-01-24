using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSliderController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> m_PooledAudioSources;

    private void OnEnable()
    {
        UpdateValues();
    }

    public void UpdateValues()
    {
        GetComponent<Slider>().value = GameManager.Instance.SelectedPlanet.GetComponent<PlanetController>().SizeIndex;
    }

    public void SetPlanetSize(float sliderValue)
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
        
        GameManager.Instance.SetPlanetScale(intVal); 
    }
}
