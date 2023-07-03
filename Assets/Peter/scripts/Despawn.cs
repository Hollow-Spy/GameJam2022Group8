using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "despawn")
        {
            Destroy(this.gameObject,0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
