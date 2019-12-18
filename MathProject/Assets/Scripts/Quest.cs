using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text quest;
    public string questValue;
    public bool done;

    public string[,] tasks =
    {
        {"H2O","HHO"},
        {"OH","OH"},
        {"CO2","COO"},
        {"COH","COH"}
    };

    void Start()
    {
        quest = GetComponent<Text>();
        int i = Random.Range(0, tasks.Length / 2);
        quest.text = tasks[i, 0].ToString();
        questValue = tasks[i, 1];
        done = false;
    }

    void Update()
    {
        if (done)
        {
            int i = Random.Range(0, tasks.Length / 2);
            quest.text = tasks[i,0].ToString();
            questValue = tasks[i,1];
            Debug.Log(questValue);
            done = false;
        }
    }
    
}

