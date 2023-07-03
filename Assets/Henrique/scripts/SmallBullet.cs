using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet : MonoBehaviour, IPoolerObject
{
    [SerializeField] float LifeTime;
    float lifetime;
    [SerializeField] float BulletSpeed;
    

    public void OnObjectSpawn()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,BulletSpeed);
        lifetime = LifeTime;

    }
    private void Update()
    {
      
       if (lifetime > 0)
        {

            lifetime -= Time.deltaTime;
        }
       else
        {
            gameObject.SetActive(false);
        }
    }
}
