using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float maxX = Screen.width;
    public float maxY = Screen.height;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
