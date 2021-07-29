using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryResists : MonoBehaviour
{
    [SerializeField] private Text _physic, _magic, _sword, _arrow;

    [SerializeField] private Resists _resists;

    private void OnEnable()
    {
        _physic.text = Convert.ToString(_resists.PhysicResist);
        _magic.text = Convert.ToString(_resists.MagicResist);
        _sword.text = Convert.ToString(_resists.SwordResist);
        _arrow.text = Convert.ToString(_resists.ArrowResist);
    }
}