using UnityEngine;
using UnityEngine.UI;

class TreasureItemPresenter : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _name;

     public string ItemName;
    [SerializeField] private string _itemCode;
    [SerializeField] private int _itemAmount;
    public int Price, ItemIndex;

    public void Render(Item item)
    {
        ItemName = item.ItemName;
        _name.text = item.ItemName;
        _icon.sprite = item.ItemIcon;
        _itemCode = item.ItemCode;
        Price = item.Price;
    }
}
