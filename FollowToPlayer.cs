using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    private Transform _heroPosition;

    private void OnEnable()
    {
        _heroPosition = _hero.transform;
        gameObject.transform.position = new Vector3(_heroPosition.position.x, _heroPosition.position.y + 20f, _heroPosition.position.z);
    }
}
