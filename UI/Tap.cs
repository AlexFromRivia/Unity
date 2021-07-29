using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] Animator TapAnim;
    private void OnMouseDown()
    {
        TapAnim.SetBool("isClicked", true);
    }
}