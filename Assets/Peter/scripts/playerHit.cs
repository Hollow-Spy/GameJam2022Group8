using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemyBullet"))
        {
            collision.gameObject.SetActive(false);
            this.GetComponentInParent<PlayerShooting>().RemoveItem();
        }
    }
}
