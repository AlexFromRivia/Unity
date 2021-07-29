using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UI;

//Скрипт применяется ко всем персонажам и НПС
public class Characteristics : MonoBehaviour
{
    //String
    [Space(5)]
    public int Damage, MaxHealth, KillExperience; //Resist - сопротивление от оружия(10 = блокируется 90% урона)

    //UI
    [Space(5)]
    public Slider HealthBar, HealthMask;
    [SerializeField] private Text _labelPrefab;

    //Шаблоны
    EnemyBehavior StatesAnimation;
	
    //Audio
    //[SerializeField] Color DamageColor; При получении урона моделька меняет цвет
    [SerializeField] AudioClip DamageSound;
    [SerializeField] AudioSource AudioSource;

    //TransformFields
    [SerializeField] Transform _parentTransform;

    void Awake()
    {
        StatesAnimation = gameObject.GetComponent<EnemyBehavior>();

        HealthBar.maxValue = MaxHealth;
        HealthBar.value = MaxHealth;

        HealthMask.maxValue = HealthBar.maxValue;
        HealthMask.value = HealthBar.value;
    }

    public void HealthControler()
    {
        StartCoroutine(HealthMaskController());
        AudioSource.PlayOneShot(DamageSound);

        if (HealthBar.value <= 0) Death();
    }

    void Death()
    {
        StatesAnimation.AnimatorController.SetBool("isDead", true);
        StatesAnimation.enabled = false;
        
        Destroy(gameObject, 5);
        C_GUI.CreateMessage(_labelPrefab, _parentTransform, "+" + Convert.ToString(KillExperience) + "XP");
    }

    IEnumerator HealthMaskController()
    {
        yield return new WaitForSeconds(0.1f);
        HealthMask.value = Mathf.Lerp(HealthMask.value, HealthBar.value, Time.deltaTime * 7);
    }
}