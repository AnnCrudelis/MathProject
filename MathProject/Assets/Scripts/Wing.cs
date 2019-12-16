using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour
{
    public Bullet bulletScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bulletScript = collision.gameObject.GetComponent<Bullet>();
            Destroy(gameObject);
        }
    }
}
