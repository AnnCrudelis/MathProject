using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public int life;
    public PlayerController playerScript;
    public Bullet bulletScript;

    void Move()
    {
        Vector3 pos = rb.position;
        pos.y -= speed * Time.deltaTime;
        rb.MovePosition(pos);
    }
    public void DMG(int dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript = collision.gameObject.GetComponent<PlayerController>();
            DMG(100);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            bulletScript = collision.gameObject.GetComponent<Bullet>();
            DMG(50);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6);
    }

    void Update()
    {
        Move();
    }
}
