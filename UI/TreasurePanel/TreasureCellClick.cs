using UnityEngine;
using UnityEngine.EventSystems;

public class TreasureCellClick : MonoBehaviour, IPointerClickHandler
{
    //Удалить эту ячейку из панели и массива, и перенести этот элемент массива в массив персонажа
    public void OnPointerClick(PointerEventData eventData)
    {
        var getParentItems = gameObject.GetComponentInParent<TreasureItems>();
        int index = gameObject.GetComponent<TreasureItemPresenter>().ItemIndex - 1;

        getParentItems.TransferToPlayerItem(index);
        getParentItems.Item.RemoveAt(index);

        getParentItems.Render(getParentItems.Item);

        Destroy(gameObject);
    }
}