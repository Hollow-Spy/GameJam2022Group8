using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInitialisation : MonoBehaviour
{
    private Vector3 startPos;
    public int timer = 0;
    private float temp;
    public Vector3 pos1;
    public Vector3 pos2;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-6);
        this.gameObject.transform.position = new Vector3(Random.Range(-9f,9f), this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < 35)
        {
            timer++;
        }
        else if (timer == 35)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            timer++;

            startPos = this.gameObject.transform.position;
            temp = this.gameObject.transform.position.x - Random.Range(1f, 3f);
            if (temp < -9.5)
            {
                temp = -9.5f;
            }
            pos1 = new Vector3(temp, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            temp = this.gameObject.transform.position.x + Random.Range(1f, 3f);
            if (temp > 9.5)
            {
                temp = 9.5f;
            }
            pos2 = new Vector3(temp, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            timer++;
        }
    }
}
