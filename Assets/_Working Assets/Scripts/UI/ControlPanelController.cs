using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour
{
    [SerializeField] private List<Button> m_AllButtons;
	
    // Use this for initialization
	void Start ()
    {
        m_AllButtons = GetComponentsInChildren<Button>().ToList();
        GameManager.Instance.PlanetWasSelected += CheckValueStatus;
        CheckValueStatus();
    }

    private void CheckValueStatus()
    {
        if (GameManager.Instance.ValueChangesScript.planet == null)
        {
            foreach (var btn in m_AllButtons)
            {
                btn.interactable = false;
            }
        }
        else
        {
            foreach (var btn in m_AllButtons)
            {
                btn.interactable = true;
            }

        }
    }
	
}
