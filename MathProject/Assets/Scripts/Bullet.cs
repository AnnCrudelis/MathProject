using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D RB2DBull;
    public Enemy enemyScript;

    void Start()
    {
        RB2DBull = GetComponent<Rigidbody2D>();
        RB2DBull.velocity = new Vector2(0, 10);
        Destroy(gameObject, 2.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
