using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public enum PeacefulStates
    {
        idle,
        attack,
        walk,
        die
    }

    private PeacefulStates PeacefulState;

    public Animator AnimatorController;
    [Space(5)]
    [SerializeField] int MoveSpeed, MinMovingDistance, RayDistance;

    bool BattleEffect; //Тестовое поле

    Vector3 StartPoz;

    void Update() => ActiveStates();

    private void FixedUpdate()
    {
        ReactionOnPlayer();
        Move();
    }

    private void Start()
    {
        StartPoz = transform.position;
        CreatePoint();
    }

    void Move() //Движение НПС
    {
        if (Vector2.Distance(transform.position, Point) < MinMovingDistance)
        {
            PeacefulState = PeacefulStates.idle;
            transform.position = transform.position;
        }

        else
        {
            PeacefulState = PeacefulStates.walk;
            transform.position += -transform.right * MoveSpeed * Time.deltaTime;
        }
    }

    void ActiveStates() //Метод, описывающий состояния
    {
        switch (PeacefulState)
        {
            case PeacefulStates.idle:
                StatesAnimation("isIdle");
                break;
            case PeacefulStates.walk:
                StatesAnimation("isWalk");
                break;
            case PeacefulStates.attack:
                StatesAnimation("isAttack");
                break;
            case PeacefulStates.die:
                StatesAnimation("isDead");
                break;
        }
    }

    void StatesAnimation(string StatesName) //Метод, редактирующий ключи состояний
    {
        switch (StatesName)
        {
            case "isIdle":
                AnimatorController.SetBool("isIdle", true);
                AnimatorController.SetBool("isWalk", false);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isWalk":
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isWalk", true);
                AnimatorController.SetBool("isAttack", false);
                break;
            case "isAttack":
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isWalk", false);
                AnimatorController.SetBool("isAttack", true);
                break;
            case "isDead":
                AnimatorController.SetBool("isIdle", false);
                AnimatorController.SetBool("isWalk", false);
                AnimatorController.SetBool("isAttack", false);
                AnimatorController.SetBool("isDead", true);
                break;
        }
    }

    //Переменные, связанные с точкой перемещения
    [SerializeField] float MaxDistanceCreatingPoint;
    Vector3 Point;

    void CreatePoint() //Создание точки, к которой пойдет NPC
    {
        Point.x = Random.Range(StartPoz.x - MaxDistanceCreatingPoint, StartPoz.x + MaxDistanceCreatingPoint);
        //Координата точки создается рандомом от стартовой до максимальной длинны от страртовой точки
        Point.y = StartPoz.y;
        Point.z = StartPoz.z;

        if (Point.x < StartPoz.x) gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        else gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);

        StartCoroutine(PointCoroutine()); //При создании новой точки сразу стартует корутина, которая создает новую точку через N секунд
    }

    IEnumerator PointCoroutine()
    {
        //Создание новой координаты происходит каждые N секунд
        yield return new WaitForSeconds(5);
        CreatePoint();
    }

    RaycastHit2D hit;
    void ReactionOnPlayer() //Метод, описывающий реакцию на игрока
    {
        hit = Physics2D.Raycast(transform.position, -transform.right, RayDistance);
        //if (hit.collider.tag == "Player") BattleEffect = true;
    }
}