using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text quest;
    bool done = true;

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
    }

    void Update()
    {
        if (done)
        {
            quest.text = tasks[Random.Range(0, 4),0].ToString();
            done = false;
        }
    }
    
}

