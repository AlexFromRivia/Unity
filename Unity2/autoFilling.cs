using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class autoFilling : MonoBehaviour
{
    [SerializeField] private Text Inscription, Inscription2;
    [SerializeField] private string testText;

    System.Random rand = new System.Random();

    IEnumerator autoFiling()
    {
        for (int i = 0; i < testText.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            Inscription.text += testText[i];

            if (i == testText.Length - 1)
            {
                StartCoroutine("backAutoFiling");
                break;
            }
        }
    }
    
    IEnumerator backAutoFiling()
    {
        for (int i = testText.Length - 1; i > - 1; i--)
        {
            yield return new WaitForSeconds(0.05f);
            Inscription2.text += testText[i];
        }
    }
        
    private void Start() => StartCoroutine("autoFiling");
}