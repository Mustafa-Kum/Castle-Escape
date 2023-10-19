using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Components")]
    [SerializeField] private RectTransform joyStickTransform;
    [SerializeField] private RectTransform joyStickBackgroundTransform;
    [SerializeField] private RectTransform joyStickCenterPosition;

    public delegate void OnStickInputValueUpdated(Vector2 inputValue);
    public event OnStickInputValueUpdated onStickValueUpdated;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPosition = eventData.position;
        Vector2 centerPosition = joyStickBackgroundTransform.position;
        Vector2 localOffSet = Vector2.ClampMagnitude(touchPosition - centerPosition, joyStickBackgroundTransform.sizeDelta.x / 9);
        Vector2 inputValue = localOffSet / joyStickBackgroundTransform.sizeDelta.x * 2;

        joyStickTransform.position = centerPosition + localOffSet;

        onStickValueUpdated?.Invoke(inputValue);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joyStickBackgroundTransform.position = eventData.position;
        joyStickTransform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joyStickBackgroundTransform.position = joyStickCenterPosition.position;
        joyStickTransform.position = joyStickBackgroundTransform.position;

        onStickValueUpdated?.Invoke(Vector2.zero);
    }
}
