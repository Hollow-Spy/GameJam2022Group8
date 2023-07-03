using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour, IPoolerObject
{
    [SerializeField] GameObject Light;

    
   public void OnObjectSpawn()
    {
        // Light.SetActive(true);
        transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(FadeNumerator());
    }

    IEnumerator FadeNumerator()
    {
       while(transform.localScale.x > 0)
        {
            yield return null;
            transform.localScale = new Vector3(transform.localScale.x - 2 * Time.deltaTime, transform.localScale.y - 2* Time.deltaTime, transform.localScale.z - 2 * Time.deltaTime);
        }
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);

    }
}
