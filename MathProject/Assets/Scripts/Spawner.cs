using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    
    public GameObject[] enemyTemplate = new GameObject [0];
    float timer = 1f;
    float minRange = 0.7f;
    float maxRange = 2.0f;
    public Score score;
    public Camera MainCamera;
    private float objectWidth;
    private float width;
    private float height;
    private Vector2 screenBounds;
    void Awake()
    {
        MainCamera = gameObject.GetComponentInParent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = enemyTemplate[0].GetComponent<SpriteRenderer>().bounds.extents.x;
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    public GameObject Spawn(Vector3 pos)
    {                
        GameObject GenEnemy = Instantiate(enemyTemplate[0], pos, Quaternion.identity);
        return GenEnemy;
    }
    

    void Update()
    {
        if (timer <= 0)
        {
            Vector3 position = new Vector3(Random.Range(-screenBounds.x + objectWidth, screenBounds.x - objectWidth), transform.position.y, 0);
            Spawn(position);
            timer = Random.Range(minRange,maxRange);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (score.currentScore % 60 == 0 && maxRange>1.0f)
        {
            maxRange-=0.3f;
        }
    }
}
