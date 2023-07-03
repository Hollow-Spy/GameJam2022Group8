using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBullet : MonoBehaviour, IPoolerObject
{
    [SerializeField] float LifeTime;
    float lifetime;
    [SerializeField] float BulletSpeed;
    [SerializeField] LayerMask enemyLayer;

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
            transform.Rotate(0, Random.Range(-5, 5), 0);
            lifetime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }

       
    }
}
