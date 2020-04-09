using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float maxX = Screen.width;
    public float maxY = Screen.height;
    public float currentHP;
    public float speed = 1.5f;
    public Enemy enemyScript;
    public float maxHp = 100;
    Gui gui;
    void Start()
    {
        gui = FindObjectOfType<Gui>();
        gui.playerIsDead = false;
        currentHP = maxHp;
        rigidbody2d = GetComponent<Rigidbody2D>();
       
    }

   
    void Move()
    {
        Vector3 playerPos = rigidbody2d.position;
        float dirX = Input.GetAxis("Horizontal");
        playerPos.x += speed * Time.deltaTime * dirX;
        playerPos.x = Mathf.Clamp(playerPos.x, -maxX, maxX);
        rigidbody2d.MovePosition(playerPos);
    }
   
    
    public void DMG(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            gui.playerIsDead = true;
            //Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            DMG(25);
        }
        if (collision.gameObject.GetComponent<IBuffable>() != null)
        {
            IBuffable buff = collision.gameObject.GetComponent<IBuffable>();
            buff.Buff(this.gameObject);
            Destroy(collision.gameObject);
        }
    }


    void Update()
    {
        Move();
    }

}
