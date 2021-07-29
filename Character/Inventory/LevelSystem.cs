using UnityEngine;
using UnityEngine.UI;
using UI;

public class LevelSystem : MonoBehaviour
{
    [Space(5)]
    public int Level = 1, NextLevelExp, ExpPoints;

    [SerializeField] Transform _parentTransform;
    [SerializeField] Text _labelPrefab;
    [SerializeField] public Slider _expBar;

    private void Awake() => _expBar.maxValue = NextLevelExp;

    public void ExpBarController()
    {
        if (_expBar.value >= _expBar.maxValue) LevelUp();
        _expBar.maxValue = NextLevelExp;
    }

    public void LevelUp()
    {
        Level++;
        _expBar.value = 0;
        NextLevelExp += 1000;
        ExpPoints += 1;

        C_GUI.CreateMessage(_labelPrefab, _parentTransform, "New level: " + Level + ", ExpPoints: " + ExpPoints);
    }
}