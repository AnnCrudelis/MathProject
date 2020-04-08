using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsBuff : MonoBehaviour, IBuffable
{
    public float lifeTime;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    public void Buff(GameObject gameObject)
    {
        gameObject.GetComponent<Score>().currentScore += 100;
    }
    void Update()
    {
        transform.position += Vector3.down*Time.deltaTime;
    }

}
