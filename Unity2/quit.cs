using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using testNS;

////////////////////////////////////////����� �������� ������ ��� ������////////////////////////////////////////////

public class quit : MonoBehaviour
{
    test tt = new test();

    void Start() => StartCoroutine("QuitCor");

    void quiter() => tt.GameQuit();

    IEnumerator QuitCor()
    {
        yield return new WaitForSeconds(5);
        quiter();
    }
}
