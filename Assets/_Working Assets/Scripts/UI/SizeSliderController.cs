using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSliderController : MonoBehaviour
{
    [SerializeField] private List<AudioSource> m_PooledAudioSources;
    [SerializeField] private Slider m_ThisSlider;

    private int m_CachedValue;

    private void OnEnable()
    {
        m_ThisSlider = GetComponent<Slider>();
        UpdateValues();
    }

    public void UpdateValues()
    {
        m_ThisSlider.value = GameManager.Instance.SelectedPlanet.GetComponent<PlanetController>().SizeIndex;
    }

    private void Update()
    {
        SetPlanetSize(m_ThisSlider.value);
    }

    public void SetPlanetSize(float sliderValue)
    {
        if (Mathf.FloorToInt(sliderValue) == m_CachedValue)
        {
            return;
        }

        m_CachedValue = Mathf.FloorToInt(sliderValue);

        print("Setting size!");
        if (GameManager.Instance.PlanetStatWasChanged != null)
        {
            print("UI interaction event called!");
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
