using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public int life;
    public PlayerController playerScript;
    public Bullet bulletScript;
    public Text myText;
    public GameObject rightWing;
    public GameObject leftWing;
    public Answer answer;
    public GameObject[] buffs;
    GameObject myBuff;

    public List<string> value = new List<string>();

    void Move()
    {
        if (rightWing != null && leftWing != null)
        {
            Vector3 pos = rb.position;
            pos.y -= speed * Time.deltaTime;
            rb.MovePosition(pos);
        }
        if (rightWing == null && leftWing == null)
        {
            Vector3 pos = rb.position;
            pos.y -= speed * Time.deltaTime;
            rb.MovePosition(pos);
        }
        if (rightWing == null && leftWing != null)
        {
            Vector3 pos = rb.position;
            pos.y -= speed * Time.deltaTime;
            pos.x -= 0.5f * speed * Time.deltaTime;
            rb.MovePosition(pos);
        }
        if (rightWing != null && leftWing == null)
        {
            Vector3 pos = rb.position;
            pos.y -= speed * Time.deltaTime;
            pos.x += 0.5f * speed * Time.deltaTime;
            rb.MovePosition(pos);
        }

    }

    public void DMG(int dmg)
    {
        life -= dmg;
        
        if (life <= 0)
        {
            Answer.strValue = myText.text.ToString();
            Destroy(gameObject);
        }
    }


    public void MyValue()
    {
        myText.text = value[Random.Range(0, value.Count)].ToString();
        float buffChance = Random.Range(0,100);
        if (buffChance>97)
        {
            myBuff = buffs[0];
        }
        if (buffChance>94 && buffChance<=97)
        {
            myBuff = buffs[1];
        }
        if (buffChance>90 && buffChance<=94)
        {
            myBuff = buffs[2];
        }
        if(buffChance>85 && buffChance<=90)
        {
            myBuff = buffs[3];
        }
        if(buffChance>80 && buffChance<=85)
        {
            myBuff = buffs[4];
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
        Destroy(gameObject, 8);
        MyValue();

    }

    void Update()
    {
        Move();       
    }
    void OnDestroy()
    {
        if(myBuff!=null)
        {
        Instantiate(myBuff,this.transform.position,Quaternion.identity);
        }
    }
}
