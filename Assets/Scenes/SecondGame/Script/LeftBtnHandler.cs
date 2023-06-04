using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LeftBtnHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.left = true;
        playerController.right = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.left = false;
    }
}
