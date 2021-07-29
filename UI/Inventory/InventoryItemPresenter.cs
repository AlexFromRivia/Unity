using UnityEngine;
using UnityEngine.UI;

class InventoryItemPresenter : MonoBehaviour
{
    #region Item type fields
    public enum ItemType
    {
        food,
        weapon,
        armor,
        usable,
        quest
    }
    public ItemType itemTypes;
    #endregion

    [SerializeField] private Image _icon;

    public string _itemName;
    [SerializeField] string _itemCode;
    [SerializeField] int _itemAmount;
    public int _price;

    public void Render(Item item)
    {
        _itemName = item.ItemName;
        _icon.sprite = item.ItemIcon;
        _itemCode = item.ItemCode;
        _price = item.Price;

        itemTypes = (ItemType)item.ItemTypes;
    }
}