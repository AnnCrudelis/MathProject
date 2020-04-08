using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuff : MonoBehaviour, IBuffable
{
    public float buffVolume;
        public float lifeTime;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }
    public void Buff(GameObject gameObject)
    {
        PlayerController player = gameObject.GetComponent<PlayerController>();
        
        if(player.currentHP<player.maxHp)
        {
            player.currentHP += buffVolume;
        }
        
    }
    void Update()
    {
        transform.position += Vector3.down*Time.deltaTime;
    }
}
