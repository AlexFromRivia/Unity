using UnityEngine;
using UnityEngine.UI;

class CalculateDamage : MonoBehaviour
{
    private enum DamageType
    {
        magic,
        physic,
        sword,
        arrow
    }

    [SerializeField] private DamageType damageType;
    [SerializeField] string Tag_WhoTakeDamage;
    [SerializeField] GameObject Player;

    Characteristics OtherChar, thisChar;
	LevelSystem thisCharLevel;
    Resists Resists;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == Tag_WhoTakeDamage)
        {
			OtherChar = collision.GetComponent<Characteristics>();

            TakeDamage(collision);

            if (OtherChar.HealthBar.value <= 0) thisCharLevel._expBar.value += OtherChar.KillExperience;
        }
    }
	
    private void Awake()
    {
        thisChar = Player.GetComponent<Characteristics>();
		thisCharLevel = Player.GetComponent<LevelSystem>();
    }

    private void TakeDamage(Collider2D col)
    {
        Resists = col.GetComponent<Resists>();

        switch (damageType)
        {
            case DamageType.physic:
                OtherChar.HealthBar.value -= (thisChar.Damage * Resists.PhysicResist) / 100;
                break;
            case DamageType.magic:
                OtherChar.HealthBar.value -= (thisChar.Damage * Resists.MagicResist) / 100;
                break;
            case DamageType.sword:
                OtherChar.HealthBar.value -= (thisChar.Damage * Resists.SwordResist) / 100;
                break;
            case DamageType.arrow:
                OtherChar.HealthBar.value -= (thisChar.Damage * Resists.ArrowResist) / 100;
                break;
        }
    }
}