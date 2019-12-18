using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed;
    public float maxX = Screen.width;
    public float maxY = Screen.height;
    public GameObject Bullet;
    public float life = 100;
    public Enemy enemyScript;
    float shotTimer = 0.0f;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Move()
    {
        Vector3 playerPos = rigidbody2d.position;
        float dirX = Input.GetAxis("Horizontal");

#if UNITY_ANDROID
        playerPos.x += speed * Time.deltaTime * GetDirectionFromTouch();

#else      
        playerPos.x += speed * Time.deltaTime * dirX;

#endif
        playerPos.x = Mathf.Clamp(playerPos.x, -maxX, maxX);
        rigidbody2d.MovePosition(playerPos);
    }
    float GetDirectionFromTouch()
    {
        float ScreenHeight = Screen.height;
        float ScreenWidth = Screen.width;
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch curTouch = myTouches[i];
            if (curTouch.position.x > ScreenWidth / 2 && curTouch.position.y < ScreenHeight / 4  )
            {
                return 1.0f;
            }
            else if (curTouch.position.x < ScreenWidth / 2 && curTouch.position.y < ScreenHeight / 4)
            {

                return -1.0f;
            }
            else if (curTouch.position.x > ScreenWidth / 2 && curTouch.position.y < ScreenHeight / 2)
            {
                Shoot();
                return 1.0f;
            }
            else if (curTouch.position.x < ScreenWidth / 2 && curTouch.position.y < ScreenHeight / 2)
            {
                Shoot();
                return -1.0f;
            }
        }
        return 0;
    }

    public void Shoot()
    {
        if (shotTimer <= 0.0f)
        {
#if UNITY_ANDROID
            GameObject BulletShot = Instantiate(Bullet, this.transform.position, Quaternion.identity);
            BulletShot.transform.position += Vector3.up;
#else
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject BulletShot = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                BulletShot.transform.position += Vector3.up;
            }
#endif
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


    void Update()
    {
        Move();
#if !UNITY_ANDROID
        Shoot();
#endif
    }
}
