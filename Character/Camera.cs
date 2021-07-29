using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _hero;

    //Сделать барьеры для камеры, чтоб она не заходила за пределы карты
     void Update() => gameObject.transform.position = new Vector2(_hero.transform.position.x, _hero.transform.position.y + 25f);
}
