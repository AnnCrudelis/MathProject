using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    
    public GameObject[] enemyTemplate = new GameObject [0];
    float timer = 0.5f;

    void Spawn()
    {                
        Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f),transform.position.y, 0);
        GameObject GenEnemy = Instantiate(enemyTemplate[0], position, Quaternion.identity);
    }
    

    void Update()
    {
        if (timer <= 0)
        {
            Spawn();
            timer = Random.Range(0.3f,2.0f);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
