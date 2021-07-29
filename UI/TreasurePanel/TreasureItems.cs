using System.Collections.Generic;
using UnityEngine;

class TreasureItems : MonoBehaviour
{
    [SerializeField] private TreasureItemPresenter _cell;
    [SerializeField] private Transform _bag;

    [SerializeField] private GameObject _hero;

    public List<Item> Item;

    void OnEnable() => Render(Item);

    public void Render(List<Item> _items)
    {
        foreach (Transform _child in _bag) Destroy(_child.gameObject);

        _items.ForEach(_item =>
        {
            _cell.ItemIndex++;

            var _renderCell = Instantiate(_cell, _bag);
            _renderCell.Render(_item);
        });

        _cell.ItemIndex = 0;
    }

    public void TransferToPlayerItem(int itemIndex)
    {
        if (Item.Count != 1) _hero.GetComponent<CharacterInventory>().Items.Add(Item[itemIndex]);
        else _hero.GetComponent<CharacterInventory>().Items.Add(Item[itemIndex]);
    }
}