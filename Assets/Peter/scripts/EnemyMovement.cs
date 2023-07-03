using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
        waiting = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.GetComponent<enemyInitialisation>().timer > 36 && !waiting)
        {
            if (this.gameObject.transform.position.x < this.gameObject.GetComponent<enemyInitialisation>().pos1.x)
            {
                StartCoroutine(wait(2,2f,4f));
                waiting = true;
            }

            if (this.gameObject.transform.position.x > this.gameObject.GetComponent<enemyInitialisation>().pos2.x)
            {
                StartCoroutine(wait(-2,2f,4f));
                waiting = true;
            }
        }
    }

    IEnumerator wait(float speed, float lower, float higher)
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(Random.Range(lower,higher));
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
        yield return new WaitForSeconds(.1f);
        waiting = false;
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3((Random.Range(0,2)-.5f)*4, 0, 0);
        waiting = false;
    }
}
