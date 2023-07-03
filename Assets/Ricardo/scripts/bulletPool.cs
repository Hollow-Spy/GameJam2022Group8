using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    [Range(0.0f, 10000.0f)]
    [SerializeField] int numberOfBullets;

    public GameObject bulletPrefab;
    List<GameObject> bulletsPool;

    // Start is called before the first frame update
    void Start()
    {
        //Create the empty pool
        bulletsPool = new List<GameObject>();

        //Create each element of the pool
        for(int i = 0; i < numberOfBullets; ++i)
        {
            //Spawn the bullet
            GameObject bullet = (GameObject)Instantiate(bulletPrefab);
            DontDestroyOnLoad(bullet);
            //Deactivate
            bullet.SetActive(false);
            //Add to the pool
            bulletsPool.Add(bullet);
        }
       
    }

    public GameObject shot()
    {
        for (int i = 0; i < numberOfBullets; ++i)
        {
            if (!bulletsPool[i].activeInHierarchy)
            {
                return bulletsPool[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
