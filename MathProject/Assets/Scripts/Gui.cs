using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui : MonoBehaviour
{
    public PlayerController playerScript;
    public SimpleHealthBar healthBar;


    void Update()
    {
        healthBar.UpdateBar(playerScript.currentHP, playerScript.maxHp);

    }
}
