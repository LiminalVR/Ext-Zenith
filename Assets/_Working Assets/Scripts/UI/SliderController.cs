using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private List<Image> _sliderMarks;
    [SerializeField] private Color _unselectedColor;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Slider _thisSlider;

    private void Start()
    {
        _thisSlider = GetComponent<Slider>();
        UpdateMarks(_thisSlider.value);
    }

    private void Update()
    {
        UpdateMarks(_thisSlider.value);
    }

    public void UpdateMarks(float sliderValue)
    {
        var _intVal = Mathf.FloorToInt(sliderValue);

        for (var i = 0; i < _sliderMarks.Count; i++)
        {
            _sliderMarks[i].color = i == _intVal ? _selectedColor : _unselectedColor;
        }
    }
}
