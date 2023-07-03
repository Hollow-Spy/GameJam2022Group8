using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBullet : MonoBehaviour, IPoolerObject
{
    [SerializeField] float LifeTime;
    float lifetime;
    [SerializeField] float BulletSpeed;


    public void OnObjectSpawn()
    {
       
        //GetComponent<Rigidbody>().velocity = 
        lifetime = LifeTime;

    }
    private void Update()
    {

        if (lifetime > 0)
        {
            transform.position += Time.deltaTime * transform.forward * BulletSpeed;
            lifetime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
