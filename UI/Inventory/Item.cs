using System;
using UnityEngine;
using UnityEngine.UI;

/* У каждого айтема есть тип
 * В зависимости от типа, в нем будет храниться определенная информация об айтеме
 * Нужно придумать как сделать вывод инфрмации от этой зависимости
 * */

interface IItem
{
    Sprite ItemIcon { get; }
    string ItemName { get; }
    string ItemCode { get; }
    int ItemAmount { get; }
    int Price { get; }
}

public class Item : MonoBehaviour, IItem
{
    #region Item type fields
    public enum ItemType
    {
        food,
        weapon,
        armor,
        quest
    }
    public ItemType ItemTypes;
    #endregion

    #region Weapon type fields
    public enum WeaponType
    {
        onehands,
        twohands
    }
    public WeaponType WeaponTypes;
    #endregion

    [SerializeField] public Sprite _itemIcon;
    [SerializeField] public string _itemName, _itemCode;
    [SerializeField] public int _price, _index, _itemAmount;

    public Sprite ItemIcon => _itemIcon;
    public string ItemName => _itemName;
    public string ItemCode => _itemCode;
    public int ItemAmount => _itemAmount;
    public int Price => _price;
}

[Serializable]
public class Weapon : Item
{
    public int PhysicDamage, MagicDamage;
}

public class Armor : Item
{
    public int PhysicResist, MagicResist, SwordResist, ArrowResist;
}

public class Food : Item
{
    public int Treatment;
}

public class Quest : Item
{
    [TextArea] public string Description;
}