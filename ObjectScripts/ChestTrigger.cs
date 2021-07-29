using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _childGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Treasure>()._treasure.Count != 0)
        {
            if (collision.tag == "Player") ActiveGameObject("On");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") ActiveGameObject("Off");
    }

    private void ActiveGameObject(string OnOff)
    {
        if (OnOff == "On")
            for (int i = 0; i < _childGameObject.Length; i++) _childGameObject[i].SetActive(true);

        else if (OnOff == "Off")
            for (int i = 0; i < _childGameObject.Length; i++) _childGameObject[i].SetActive(false);
    }
}