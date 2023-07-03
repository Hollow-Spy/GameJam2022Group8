using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrail : MonoBehaviour
{


    ObjectPooler objectpooler;
    IEnumerator Spawner;



    private void Start()
    {
        objectpooler = ObjectPooler.Instance;

    }

    public void StartTrail()
    {
        Spawner = Trail();
         StartCoroutine(Spawner);
    }
    public void EndTrail()
    {
        
        StopCoroutine(Spawner);
    }

    IEnumerator Trail()
    {
        while(true)
        {
           objectpooler.SpawnFromPool("PlayerDash", transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.007f);
        }
       
    }
}
