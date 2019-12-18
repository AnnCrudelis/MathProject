using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Answer : MonoBehaviour
{

    public Quest questScript;
    Text answer;
    public PlayerController playerScript;
    public static string strValue = "";
    void Start()
    {
        answer = GetComponent<Text>();
    }

    void Update()
    {
        if (questScript.questValue.IndexOf(strValue) >= 0)
        {
            answer.text = answer.text.ToString() + strValue.ToString();
            strValue = "";

            if (questScript.questValue.Length <= answer.text.ToString().Length)
            {
                if (String.Equals(questScript.questValue, answer.text.ToString(), StringComparison.Ordinal))
                {
                    Debug.Log("Done");
                }
                else
                {
                    Debug.Log("Auch");
                    playerScript.DMG(25);
                }
                questScript.done = true;
                answer.text = null;
            }

        }
        //Сравнение строк квеста и ответа, и ограничение на длину ответа относительно квеста
        //И рефакторинг
    }
}
