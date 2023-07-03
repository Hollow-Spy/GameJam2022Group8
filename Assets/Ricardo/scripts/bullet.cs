using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    [SerializeField] float lifeTime;
    float speed;

    Transform bulletTransform;
    GameObject bulletGO;

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //forWardMovement
        bulletTransform.Translate(new Vector3(0.0f, 0.0f, -1.0f) * speed * Time.deltaTime);
    }

    public void shot(float speed, Vector3 position, Quaternion rotation)
    {
        bulletTransform = GetComponent<Transform>();
        this.speed = speed;
        bulletTransform.position = position;
        bulletTransform.rotation = rotation;
        gameObject.SetActive(true);
        StartCoroutine(deactivateBullet(lifeTime));
    }

    IEnumerator deactivateBullet(float time)
    {
        yield return new WaitForSeconds(time);
        
        gameObject.SetActive(false);
    }
}
