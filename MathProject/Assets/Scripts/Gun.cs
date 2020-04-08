using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunStates currentState;
    public float speed = 1.5f;
    public float speedAttack = 0.4f;
    public GameObject Bullet;
    private float shotTimer = 0.0f;

    private void Awake()
    {
        EnterState(GunStates.Simple);
    }
    public enum GunStates : int
    {
        Simple,
        Double,
        Multiple,
        Rifle
    }
    private void EnterState(GunStates state)
    {
        currentState = state;
    }
    public void ChangeState(GunStates state)
    {
        if (currentState == GunStates.Simple)
        {
            int nextState = Random.Range(1,3);
            state = (GunStates)nextState;
        }
        if (currentState == GunStates.Double)
        {
            int nextState = Random.Range(2,3);
            state = (GunStates)nextState;
        }
        if (currentState == GunStates.Multiple)
        {
            int nextState = Random.Range(0,1);
            state = (GunStates)nextState;
        }
        if (currentState == GunStates.Rifle)
        {
            int nextState = Random.Range(0,2);
            state = (GunStates)nextState;
        }
        EnterState(state);
    }


    public void Shoot(GunStates state)
    {
        if (state == GunStates.Simple)
        {
            SimpleShoot();
        }
        if (state == GunStates.Double)
        {
            DoubleShoot();
        }
        if (state == GunStates.Multiple)
        {
            MultipleShoot();
        }
        if (state == GunStates.Rifle)
        {
            MultipleShoot();
        }
    }

    public void SimpleShoot()
    {
        if (shotTimer <= 0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject BulletShot = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                BulletShot.transform.position += Vector3.up;
            }
            shotTimer = speedAttack;
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
    }
    public void DoubleShoot()
    {
        if (shotTimer <= 0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject BulletShotLeft = Instantiate(Bullet, this.transform.position + Vector3.left*0.5f, Quaternion.identity);
                GameObject BulletShotRight = Instantiate(Bullet, this.transform.position + Vector3.right*0.5f, Quaternion.identity);
                BulletShotLeft.transform.position += Vector3.up * speed;
                BulletShotRight.transform.position += Vector3.up * speed;
            }
            shotTimer = speedAttack;
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
    }
    public void MultipleShoot()
    {
        if (shotTimer <= 0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject BulletShot1 = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                GameObject BulletShot2 = Instantiate(Bullet, this.transform.position+Vector3.down, Quaternion.identity);
                //GameObject BulletShot3 = Instantiate(Bullet, this.transform.position+Vector3.down*0.5f, Quaternion.identity);
                BulletShot1.transform.position += Vector3.up * speed;
                BulletShot2.transform.position += Vector3.up * speed;
                //BulletShot3.transform.position += Vector3.up * speed;
            }
            shotTimer = speedAttack;
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
    }
    public void RifleShoot()
    {
        if (shotTimer <= 0.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject BulletShot1 = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                BulletShot1.transform.position += Vector3.up * speed * 3;
            }
            shotTimer = speedAttack;
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
    }

    void Update()
    {
        Shoot(currentState);
    }


}
