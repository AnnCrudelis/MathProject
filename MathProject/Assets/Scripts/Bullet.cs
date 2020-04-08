using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D RB2DBull;
    public Enemy enemyScript;
    public Wing wingScript;
    public GameObject[] explosion;
 

    void Start()
    {
        RB2DBull = GetComponent<Rigidbody2D>();
        RB2DBull.velocity = new Vector2(0, 10);
        Destroy(gameObject, 2.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
        GameObject newExplosion = Instantiate(explosion[Random.Range(0,explosion.Length-1)],transform.position,Quaternion.identity);
        Destroy(newExplosion,0.35f);
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "RightWing")
        {
            wingScript = collision.gameObject.GetComponent<Wing>();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "LeftWing")
        {
            wingScript = collision.gameObject.GetComponent<Wing>();
            Destroy(gameObject);
        }
        }
    }
    void Update()
    {
        
    }
}
