using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAttackBuff : MonoBehaviour, IBuffable
{
        public float lifeTime;
    void Start()
    {
        Destroy(this, lifeTime);
    }
    public float buffVolume = 0.05f;
    public void Buff(GameObject gameObject)
    {
        float speedAttack = gameObject.GetComponentInChildren<Gun>().speedAttack;
        if(speedAttack>=0.15f)
        {
            speedAttack -= buffVolume;
        }
    }
    void Update()
    {
        transform.position += Vector3.down*Time.deltaTime;
    }
}
