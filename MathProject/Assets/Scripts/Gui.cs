using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui : MonoBehaviour
{
    public PlayerController playerScript;
    public SimpleHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateBar(playerScript.life, 100);
        if (playerScript.life >= 75)
        {
            healthBar.UpdateColor(Color.green);
        }
        else if (playerScript.life >= 50)
        {
            healthBar.UpdateColor(Color.yellow);
        }
        else 
        {
            healthBar.UpdateColor(Color.red);
        }

    }
}
