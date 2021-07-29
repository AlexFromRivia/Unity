using UnityEngine;
using System.Collections.Generic;

class InventoryItems : MonoBehaviour
{
    [SerializeField] private InventoryItemPresenter _cell;
    public List<Item> _item;
    [SerializeField] private Transform _bag;

    void OnEnable() => Render(_item);

    public void Render(List<Item> _items)
    {
        foreach (Transform _child in _bag) Destroy(_child.gameObject);
        _items.ForEach(_item =>
        {
            var _renderCell = Instantiate(_cell, _bag);
            _renderCell.Render(_item);
        });
    }
}