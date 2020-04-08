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
        {"Вода","HHO"},
        {"Гидроксид","OH"},
        {"Углекислый газ","COO"},
        {"Метан","CHHHH"},
    };

    void Start()
    {
        quest = GetComponent<Text>();
        int i = Random.Range(0, tasks.Length / 2);
        quest.text = tasks[i, 0].ToString();
        questValue = tasks[i, 1];
        done = false;
        Debug.Log(questValue);
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

