using System;
using UnityEngine;
using UnityEngine.EventSystems;

class CellHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryItemPresenter _itemInfo;
    private ShowInfoAboutItem GetInfo;

    private GameObject _eventSystem;

    private void Start() => _eventSystem = GameObject.Find("EventSystem");

    public void OnPointerEnter(PointerEventData g)
    {
        _itemInfo = gameObject.GetComponent<InventoryItemPresenter>();

        GetInfo = _eventSystem.GetComponent<ShowInfoAboutItem>();
        GetInfo.ShowInfoPanel(_itemInfo._itemName, Convert.ToString(_itemInfo._price), Convert.ToString(_itemInfo.itemTypes));

        gameObject.transform.localScale = new Vector2(1,1) * 1.05f;
    }

    public void OnPointerExit(PointerEventData g)
    {
        GetInfo.CloseInfoPanel();
        gameObject.transform.localScale = new Vector2(1, 1);
    }
}