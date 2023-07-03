using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbsorv : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("item"))
        {
            if(other.GetComponent<ItemGiver>().active)
            {
                GetComponent<PlayerShooting>().AddNewItem(other.GetComponent<ItemGiver>().ItemName);
               
                Destroy(other.gameObject);
               
            }
           
        }

        if(other.CompareTag("upgrade"))
        {
            int rand = Random.Range(0, 2);
            string bullet;
            switch (rand)
            {
                case 0:
                    bullet = "TripleBullet";
                    break;
                default:
                    bullet = "SmallBullet";

                    break;
            }
            GetComponent<PlayerShooting>().AddNewBullet(bullet);
            Destroy(other.gameObject);
        }
    }
}
