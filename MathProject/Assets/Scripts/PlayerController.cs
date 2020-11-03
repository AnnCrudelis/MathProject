using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float currentHP;
    public float speed = 1.5f;
    public Enemy enemyScript;
    public float maxHp = 100;
    Gui gui;
    private float width;
    private float height;
    public VariableJoystick joystick;
    Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;


    void Start()
    {
        MainCamera = gameObject.GetComponentInParent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        gui = FindObjectOfType<Gui>();
        gui.playerIsDead = false;
        currentHP = maxHp;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    
#if UNITY_ANDROID
    void Move()
    {
        speed = screenBounds.x;
        Vector3 direction = Vector3.right * joystick.Horizontal;
        Vector3 playerPos = rigidbody2d.position;
        playerPos.x += speed * Time.deltaTime * direction.x;
        playerPos.x = Mathf.Clamp(playerPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        playerPos.y = -4;
        rigidbody2d.MovePosition(playerPos);
    }
#else
        void Move()
    {
        Vector3 playerPos = rigidbody2d.position;
        float dirX = Input.GetAxis("Horizontal");
        playerPos.x += speed * Time.deltaTime * dirX;
        playerPos.x = Mathf.Clamp(playerPos.x, -maxX, maxX);
        rigidbody2d.MovePosition(playerPos);
    }
#endif



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
