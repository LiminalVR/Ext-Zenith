using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mathf = UnityEngine.Mathf;

public class MaterialSliderController : SliderController
{

    private int m_CachedValue;

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Start()
    {
        base.Start();
        UpdateValues();
    }

    public void UpdateValues()
    {
        if (GameManager.Instance.SelectedPlanet == null) return;
        _thisSlider.value = GameManager.Instance.SelectedPlanet.GetComponent<PlanetController>().MaterialIndex;
        SetPlanetMaterial(_thisSlider.value, true);
    }

    public override void Update()
    {
        base.Update();
        SetPlanetMaterial(_thisSlider.value);
    }

    public void SetPlanetMaterial(float sliderValue, bool ignoreSnap = false)
    {
        if (_snapToWholeNumber && !m_snapped && !ignoreSnap)
        {
            return;
        }

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

        GameManager.Instance.SetPlanetMaterial(_intVal);
        GameManager.Instance.UpdateAllCanvasValues();
    }
}
