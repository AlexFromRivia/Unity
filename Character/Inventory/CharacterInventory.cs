using UnityEngine;
using System.Collections.Generic;

class CharacterInventory : MonoBehaviour
{
    [SerializeField] public int _goldAmount;
    [SerializeField] private GameObject GUI;
    [SerializeField] private InventoryItems _inventoryItems;

    public List<Item> Items;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GUI.activeSelf == false)
            {
                GUI.SetActive(true);
                _inventoryItems._item = Items;
            }
            else GUI.SetActive(false);
        }
    }
}