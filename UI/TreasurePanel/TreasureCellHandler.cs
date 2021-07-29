using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TreasureCellHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite _deffaultSprite, _handleSprite;

    public void OnPointerEnter(PointerEventData eventData) =>
        gameObject.GetComponent<Image>().sprite = _handleSprite;

    public void OnPointerExit(PointerEventData eventData) =>
        gameObject.GetComponent<Image>().sprite = _deffaultSprite;
}