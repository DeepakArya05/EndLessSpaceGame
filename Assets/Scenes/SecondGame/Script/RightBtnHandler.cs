using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RightBtnHandler : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.right = true;
        playerController.left = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.right = false;
    }
}
