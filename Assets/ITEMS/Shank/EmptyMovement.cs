using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyMovement : MonoBehaviour
{
    bool right;
    float height=.5f;
  
    void Start()
    {
     
        int r = Random.Range(0, 2);
        if(r==0)
        {
            right = true;
        }
        else
        {
            right = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(right)
        {
            transform.position += new Vector3(Random.Range(.02f, .1f), 0, 2.5f / height * Time.deltaTime );
        }
        else
        {
            transform.position += new Vector3(Random.Range(-.03f, -.1f), 0, 2.5f / height * Time.deltaTime);

        }
      
        if(height > 0)
        {
           
            height -= .8f * Time.deltaTime;
        }
        else
        {
            height = -2;
        }
        
    }
}
