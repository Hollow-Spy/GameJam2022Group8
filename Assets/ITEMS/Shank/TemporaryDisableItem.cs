using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryDisableItem : MonoBehaviour
{
   

    private void Start()
    {
        gameObject.tag = "Untagged";
        GetComponent<ItemGiver>().active = false;
      //  GetComponent<Collider>().isTrigger = false;
        StartCoroutine(ReEnable());
    }
    IEnumerator ReEnable()
    {
        yield return new WaitForSeconds(.4f);
        //GetComponent<Collider>().isTrigger = true;
        GetComponent<ItemGiver>().active = true;


        gameObject.tag = "item";

    }

}
