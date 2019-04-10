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
    [SerializeField] private bool _snapToWholeNumber;
    [SerializeField] private Vector2 _snapRange;

    private int m_nextWhole;
    private int m_lastWhole;

    private void Start()
    {
        _thisSlider = GetComponent<Slider>();
        UpdateMarks(_thisSlider.value);
    }

    public void ValueChanged()
    {
        if (!_snapToWholeNumber) return;

        m_nextWhole = Mathf.CeilToInt(_thisSlider.value);
        m_lastWhole = Mathf.FloorToInt(m_nextWhole-1);

        if (_thisSlider.value >= m_nextWhole + _snapRange.x && _thisSlider.value <= m_nextWhole + _snapRange.y)
        {
            _thisSlider.value = m_nextWhole;
        }
        else if (_thisSlider.value >= m_lastWhole + _snapRange.x && _thisSlider.value <= m_lastWhole + _snapRange.y)
        {
            _thisSlider.value = m_lastWhole;
        }
        
    }

    private void Update()
    {
        if (_thisSlider == null) return;

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
