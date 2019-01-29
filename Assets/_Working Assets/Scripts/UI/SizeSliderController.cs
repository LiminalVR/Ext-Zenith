using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSliderController : MonoBehaviour
{
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

        if (GameManager.Instance.PlanetStatWasChanged != null)
        {
            GameManager.Instance.PlanetStatWasChanged.Invoke();
        }

        var intVal = Mathf.FloorToInt(sliderValue);
        
        GameManager.Instance.SetPlanetScale(intVal,1); 
    }
}
