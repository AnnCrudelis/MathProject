using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    public Quest quest;
    Text answer;
    public static string strValue = "";
    void Start()
    {
        answer = GetComponent<Text>();
    }

    void Update()
    {
        if (quest.quest.text.ToString().IndexOf(strValue) >= 0)
        {
            answer.text = answer.text.ToString() + strValue.ToString();
            strValue = "";
        }
        //Сравнение строк квеста и ответа, и ограничение на длину ответа относительно квеста
        //И рефакторинг
    }
}
