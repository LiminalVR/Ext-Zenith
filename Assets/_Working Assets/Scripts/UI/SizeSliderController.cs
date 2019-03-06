using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSliderController : MonoBehaviour
{
    [SerializeField] private Slider _thisSlider;

    private int m_CachedValue;

    private void OnEnable()
    {
        _thisSlider = GetComponent<Slider>();
        UpdateValues();
    }

    public void UpdateValues()
    {
        
        _thisSlider.value = GameManager.Instance.SelectedPlanet.GetComponent<PlanetController>().SizeIndex;
    }

    private void Update()
    {
        SetPlanetSize(_thisSlider.value);
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

        var _intVal = Mathf.FloorToInt(sliderValue);
        
        GameManager.Instance.SetPlanetScale(_intVal,1); 
    }
}
