using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DiegeticButton : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public UnityEvent TriggeredEvents;
    
    [SerializeField] private Image thisImage;

    [SerializeField] private Color enabledCol = new Color(1, 1, 1, 1);
    [SerializeField] private Color disabledCol = new Color(0.39f, 0.39f, 0.39f, 1);

    private bool _interactable = true;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (_interactable == false)
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
        if (thisImage == null)
        {
            return;
        }

        thisImage.sprite = nSprite;
    }

    public virtual void SetInteractable(bool nState)
    {
        _interactable = nState;

        //if nsState == true use the enabled color, else use the disabled color.

        GetComponent<MeshRenderer>().material.color = nState ? enabledCol : disabledCol;
    }

    [ContextMenu("Click")]
    public virtual void TestClick()
    {
        TriggeredEvents.Invoke();
    }

   
    //setup to display text on hover and setup image stuff.
}
