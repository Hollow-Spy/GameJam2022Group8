using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletCollision : MonoBehaviour
{
    PlayerShooting shootscript;
    private void Start()
    {
     shootscript =   GetComponent<PlayerShooting>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("enemyBullet"))
        {
            shootscript.RemoveItem();
            other.gameObject.SetActive(false);
            //Do something more
        }
    }


}
