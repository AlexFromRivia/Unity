using UnityEngine;

//Как-нибудь продумать анимацию полета - когда персонаж не стоит на земле
public class PlayerControll : MonoBehaviour
{
    enum States
    {
        idle,
        run,
        jump,
        flying,
        attack,
        crouch
    }

    [SerializeField] private GameObject _treasurePanel, _treasureContent;

    [SerializeField] Animator AnimatorController;
    [SerializeField] States state;

    [SerializeField] float Speed, Acceleration, JumpSpeed, RayDistance;
    [SerializeField] Vector2 Direction;

    //ControlButtons
    [SerializeField] KeyCode Jump, RightRun, LeftRun, AttackRight, AttackLeft, PickUp;

    void FixedUpdate()
    {
        PlayerAnimation();

        if (Input.GetKeyDown(Jump))
        {
            state = States.jump;
            _treasurePanel.SetActive(false);

            HeroRB.AddForce(Direction.normalized * (Acceleration * 1000), ForceMode2D.Impulse);

            if (Input.GetKey(LeftRun))
            {
                _treasurePanel.SetActive(false);

                gameObject.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                HeroRB.velocity = new Vector2(-JumpSpeed, 0);
                HeroRB.AddForce(Direction.normalized * (Acceleration * 1000), ForceMode2D.Impulse);
            }

            if (Input.GetKey(RightRun))
            {
                _treasurePanel.SetActive(false);

                gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                HeroRB.velocity = new Vector2(JumpSpeed, 0);
                HeroRB.AddForce(Direction.normalized * (Acceleration * 1000), ForceMode2D.Impulse);
            }
        }

        else if (Input.GetKey(LeftRun) && !(Input.GetKey(Jump)))
        {
            state = States.run;
            gameObject.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            HeroRB.velocity = new Vector2(-Speed, 0);
        }

        else if (Input.GetKey(RightRun))
        {
            gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            state = States.run;
            HeroRB.velocity = new Vector2(Speed, 0);
        }

        else if (Input.GetKey(AttackLeft))
        {
            gameObject.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            state = States.attack;
        }

        else if (Input.GetKey(AttackRight))
        {
            gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            state = States.attack;
        }

        else state = States.idle;
    }

    Rigidbody2D HeroRB;

    private void Start() => HeroRB = gameObject.GetComponent<Rigidbody2D>();

    private void ActiveState(string StateName) //Метод, редактирующий ключи, в зависимости от состояния персонажа
    {
        switch (StateName)
        {
            case "isIdle":
                AnimatorController.SetBool("isIdle", true);
                AnimatorController.SetBool("isJump", false);
                AnimatorController.SetBool("isRun", false);
                AnimatorController.SetBool("isCrouch", false);
                AnimatorController.SetBool("isFlying", false);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isJump":
                _treasurePanel.SetActive(false);
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isJump", true);
                AnimatorController.SetBool("isRun", false);
                AnimatorController.SetBool("isCrouch", false);
                AnimatorController.SetBool("isFlying", false);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isRun":
                _treasurePanel.SetActive(false);
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isJump", false);
                AnimatorController.SetBool("isRun", true);
                AnimatorController.SetBool("isCrouch", false);
                AnimatorController.SetBool("isFlying", false);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isCrouch":
                _treasurePanel.SetActive(false);
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isJump", false);
                AnimatorController.SetBool("isRun", false);
                AnimatorController.SetBool("isCrouch", true);
                AnimatorController.SetBool("isFlying", false);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isFlying":
                _treasurePanel.SetActive(false);
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isJump", false);
                AnimatorController.SetBool("isRun", false);
                AnimatorController.SetBool("isCrouch", false);
                AnimatorController.SetBool("isFlying", true);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isAttack":
                _treasurePanel.SetActive(false);
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isJump", false);
                AnimatorController.SetBool("isRun", false);
                AnimatorController.SetBool("isCrouch", false);
                AnimatorController.SetBool("isFlying", false);
                AnimatorController.SetBool("isAttack", true);
                break;
        }
    }

    private void PlayerAnimation() //Этот метод должен вызываться каждый кадр, тк он решает, какое состояние принимает персонаж
    {
        switch (state)
        {
            case States.idle:
                ActiveState("isIdle");
                break;
            case States.run:
                ActiveState("isRun");
                break;
            case States.jump:
                ActiveState("isJump");
                break;
            case States.crouch:
                ActiveState("isCrouch");
                break;
            case States.flying:
                ActiveState("isFlying");
                break;
            case States.attack:
                ActiveState("isAttack");
                break;
        }
    }


    //Почему-то не всегда нажимается кнопка открытия
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(PickUp))
        {
            if (collision.tag == "Treasure")
            {
                if (collision.GetComponent<Treasure>()._treasure.Count != 0)
                {
                    _treasureContent.GetComponent<TreasureItems>().Item = collision.GetComponent<Treasure>()._treasure;
                    _treasurePanel.SetActive(true);
                }
                else Debug.Log("Empty");
            }
        }
    }
}