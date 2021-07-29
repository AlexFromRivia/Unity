using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace testNS
{
    public class test : MonoBehaviour
    {
        int ttt, cheakpoint;

        [SerializeField] Text timer;
        [SerializeField] Image background;

        public void StartTimer() => StartCoroutine("timerCor");

        IEnumerator timerCor()
        {
            cheakpoint = 10;
            var rand = new System.Random();

            for (; ; )
            {
                yield return new WaitForSeconds(0.1f);

                ttt = Convert.ToInt32(timer.text);
                ttt++;

                if (ttt == cheakpoint)
                {
                    cheakpoint += 10;
                    background.GetComponent<Image>().color = new Color32(Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)), 100);
                }

                timer.text = Convert.ToString(ttt);

                if (ttt == 100)
                {
                    Application.LoadLevel("testScene");
                    break;
                }
            }
        }

        public void GameQuit() => Application.Quit();
    }
}