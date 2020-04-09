using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGunBuff : MonoBehaviour, IBuffable
{
    public float lifeTime;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }    
    public void Buff(GameObject gameObject)
    {
        Gun gun = gameObject.GetComponentInChildren<Gun>();
        gun.ChangeState(gun.currentState);
    }
    void Update()
    {
        transform.position += Vector3.down*Time.deltaTime;
    }
}
