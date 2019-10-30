using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed;
    public float maxX;
    public float maxY;
    public GameObject Bullet;
    public float shotTimer = 0.0f;
    public float life = 100;
    public Enemy enemyScript;


    void Move()
    {
        Vector3 playerPos = rigidbody2d.position;

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        playerPos.y += speed * Time.deltaTime * dirY;
        playerPos.y = Mathf.Clamp(playerPos.y, -maxY, maxY);
        playerPos.x += speed * Time.deltaTime * dirX;
        playerPos.x = Mathf.Clamp(playerPos.x, -maxX, maxX);
        rigidbody2d.MovePosition(playerPos);
    }

    public void Shoot()
    {
        if (shotTimer <= 0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject BulletShot = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                BulletShot.transform.position += Vector3.up;
            }
            shotTimer = Random.Range(0.3f, 0.5f);
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }

    }
    public void DMG(float dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            DMG(25);
        }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Shoot();
    }
}
