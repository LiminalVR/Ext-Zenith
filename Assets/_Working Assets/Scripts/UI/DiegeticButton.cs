using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DiegeticButton : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public UnityEvent TriggeredEvents;
    
    [SerializeField] private Image _thisImage;
    [SerializeField] private Color _enabledCol = new Color(1, 1, 1, 1);
    [SerializeField] private Color _disabledCol = new Color(0.39f, 0.39f, 0.39f, 1);

    private bool m_Interactable = true;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (m_Interactable == false)
        {
            return;
        }
        TriggeredEvents.Invoke();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }


    public virtual void SetupButton(Sprite nSprite)
    {
        if (_thisImage == null)
        {
            return;
        }

        _thisImage.sprite = nSprite;
    }

    public virtual void SetInteractable(bool nState)
    {
        m_Interactable = nState;

        GetComponent<MeshRenderer>().material.color = nState ? _enabledCol : _disabledCol;
    }
}
