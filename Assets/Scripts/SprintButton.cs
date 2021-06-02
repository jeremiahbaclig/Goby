using UnityEngine.EventSystems;
using UnityEngine;

public class SprintButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.isSprinting = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.isSprinting = false;
    }
}
