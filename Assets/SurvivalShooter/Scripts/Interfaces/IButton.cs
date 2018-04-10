using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IButton : IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Sprite SPRITE
    {
        get;
        set;
    }

    new void OnPointerClick(PointerEventData pointerEventData);
    new void OnPointerEnter(PointerEventData pointerEventData);
    new void OnPointerExit(PointerEventData pointerEventData);
}
