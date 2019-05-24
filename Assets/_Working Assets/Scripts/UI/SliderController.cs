using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] protected List<Image> _sliderMarks;
    [SerializeField] protected Color _unselectedColor;
    [SerializeField] protected Color _selectedColor;
    [SerializeField] protected Slider _thisSlider;
    [SerializeField] protected bool _snapToWholeNumber;
    [SerializeField] protected Vector2 _snapRange;

    protected int m_nextWhole;
    protected int m_lastWhole;
    protected bool m_snapped;

    public virtual void OnEnable()
    {
    }

    public virtual void Start()
    {
        _thisSlider = GetComponent<Slider>();
        UpdateMarks(_thisSlider.value,true);
    }

    public virtual void ValueChanged()
    {
        if (!_snapToWholeNumber) return;

        m_nextWhole = Mathf.CeilToInt(_thisSlider.value);
        m_lastWhole = Mathf.FloorToInt(_thisSlider.value);

        if (_thisSlider.value >= m_nextWhole + _snapRange.x && _thisSlider.value <= m_nextWhole + _snapRange.y)
        {
            _thisSlider.value = m_nextWhole;
            m_snapped = true;
        }
        else if (_thisSlider.value >= m_lastWhole + _snapRange.x && _thisSlider.value <= m_lastWhole + _snapRange.y)
        {
            _thisSlider.value = m_lastWhole;
            m_snapped = true;
        }
        else
        {
            m_snapped = false;
        }
    }

    public virtual void Update()
    {
        if (_thisSlider == null) return;

        UpdateMarks(_thisSlider.value);
    }

    public virtual void UpdateMarks(float sliderValue, bool ignoreSnap = false)
    {
        if (_snapToWholeNumber && !m_snapped && !ignoreSnap)
        {
            return;
        }

        var _intVal = Mathf.FloorToInt(sliderValue);

        for (var i = 0; i < _sliderMarks.Count; i++)
        {
            _sliderMarks[i].color = i == _intVal ? _selectedColor : _unselectedColor;
        }
    }
}
