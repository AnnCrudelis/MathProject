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
            
            if (questScript.questValue.Contains(strValue.ToString()))
            {
                Debug.Log(questScript.questValue.IndexOf(strValue));
                string newQuest = questScript.questValue.Remove(questScript.questValue.IndexOf(strValue),strValue.Length);
                questScript.questValue = newQuest;
                Debug.Log("Hit");
                Debug.Log(questScript.questValue);
            }
            else
            {
                Debug.Log("Auch");
                playerScript.DMG(25);
                questScript.done = true;
                answer.text = null;
            }

            if (questScript.questValue.Length <= 0)
            {
                Debug.Log("Done");
                playerScript.GetComponent<Score>().currentScore += 20;
                questScript.done = true;
                answer.text = null;
            }
            strValue = "";
            

        }

    }
}
