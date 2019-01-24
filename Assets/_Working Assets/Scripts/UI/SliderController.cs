﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private List<Image> m_SliderMarks;
    [SerializeField] private Color m_UnselectedColor;
    [SerializeField] private Color m_SelectedColor;

    private void Start()
    {
        UpdateMarks(GetComponent<Slider>().value);
    }

    public void UpdateMarks(float sliderValue)
    {
        var intVal = Mathf.FloorToInt(sliderValue);

        for (var i = 0; i < m_SliderMarks.Count; i++)
        {
            m_SliderMarks[i].color = i == intVal ? m_SelectedColor : m_UnselectedColor;
        }
    }
}
