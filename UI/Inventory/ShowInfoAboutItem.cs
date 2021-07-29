using UnityEngine;
using UnityEngine.UI;

public class ShowInfoAboutItem : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

    [SerializeField] private GameObject _weaponInfoPanel, _armorInfoPanel;

    [SerializeField] private Text _name, _price;

    public void ShowInfoPanel(string Name, string Price, string ItemType)
    {
        _infoPanel.SetActive(true);
        _name.text = Name;
        _price.text = Price;

        switch (ItemType)
        {
            case "Weapon":
                ShowWeaponInfo();
                break;
            case "Armor":
                ShowArmorInfo();
                break;
        }
    }

    public void CloseInfoPanel()
    {
        _infoPanel.SetActive(false);
        _name.text = "";
        _price.text = "";
    }

    private void ShowWeaponInfo()
    {
        _weaponInfoPanel.SetActive(true);
    }
    private void ShowArmorInfo()
    {
        _weaponInfoPanel.SetActive(true);
    }
    private void ShowFoodInfo()
    {
        _weaponInfoPanel.SetActive(true);
    }
    private void ShowQuestInfo()
    {
        _weaponInfoPanel.SetActive(true);
    }
}
