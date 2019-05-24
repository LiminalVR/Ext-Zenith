using UnityEngine;


public class SizeSliderController : SliderController
{

    private int m_CachedValue;


    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Start()
    {
        base.Start();
        _thisSlider.onValueChanged.AddListener(delegate { ValueChanged(); });
        UpdateValues();
    }

    public void UpdateValues()
    {
        if (GameManager.Instance.SelectedPlanet == null) return;
        _thisSlider.value = GameManager.Instance.SelectedPlanet.GetComponent<PlanetController>().SizeIndex;
        SetPlanetSize(_thisSlider.value, true);
    }

    public override void Update()
    {
        base.Update();
        SetPlanetSize(_thisSlider.value);
    }

    public void SetPlanetSize(float sliderValue, bool ignoreSnap = false)
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
        
        GameManager.Instance.SetPlanetScale(_intVal,1);
        GameManager.Instance.UpdateAllCanvasValues();
    }
}
