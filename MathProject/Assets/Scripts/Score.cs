using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public float currentScore = 0;
    
    void Start()
    {
    }
    void Update()
    {
        score.text = currentScore.ToString();
    }


}
