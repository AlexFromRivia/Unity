using System;
using UnityEngine;
using UnityEngine.UI;

class InventoryLeftPanel : MonoBehaviour
{
    [SerializeField] GameObject Pers;
    LevelSystem LevelSet;

    [SerializeField] Text Level, Exp, NextLevelExp, ExpPoints;

    void OnEnable()
    {
        LevelSet = Pers.GetComponent<LevelSystem>();
        
        Level.text = Convert.ToString(LevelSet.Level);
        Exp.text = Convert.ToString(LevelSet._expBar.value);
        NextLevelExp.text = Convert.ToString(LevelSet.NextLevelExp);
        ExpPoints.text = Convert.ToString(LevelSet.ExpPoints);
    }
}