using System;
using UnityEngine;
using UnityEngine.UI;
class InventoryGold : MonoBehaviour
{
    [SerializeField] private Text _goldText;
    [SerializeField] private CharacterInventory _goldAmountInCharInv;

    private void OnEnable() => _goldText.text = Convert.ToString(_goldAmountInCharInv._goldAmount);
}