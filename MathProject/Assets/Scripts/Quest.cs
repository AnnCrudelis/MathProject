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
    public Score score;

    int tasksLength = 4;
    public string[,] tasks =
    {
        {"Вода","HHO"},
        {"Гидроксид","OH"},
        {"Углекислый газ","COO"},
        {"Метан","CHHHH"},
        {"Аммиак","NHHH"},
        {"Азотная кислота","HNOOO"},
        {"Карбонат кальция","CaCOOO"},
        {"Гидрид кальция","CaHH"},
        {"Угольная кислота","HHCOOO"}, 
        {"Серная кислота","HHSOOOO"},
        {"Сероуглерод","CSS"},
        {"Сульфат кальция","CaSOOOO"}
    };

    void Start()
    {
        
        quest = GetComponent<Text>();
        int i = Random.Range(0, tasksLength / 2);
        quest.text = tasks[i, 0].ToString();
        questValue = tasks[i, 1];
        done = false;
        Debug.Log(questValue);
    }

    void Update()
    {
        if (done)
        {
            if (score.currentScore%60 == 0 && tasksLength<tasks.Length)
            {
                tasksLength+=2;
            }
            int i = Random.Range(0, tasksLength / 2);
            quest.text = tasks[i,0].ToString();
            questValue = tasks[i,1];
            Debug.Log(questValue);
            done = false;
        }
    }
    
}

