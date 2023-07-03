using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextSceneSpawnSet : MonoBehaviour
{
    [SerializeField] Transform SpawnPlane;
    Vector3 warpPosition = Vector3.zero;
    Transform PlayerT;

    private void Awake()
    {
         //PlayerT = GameObject.FindGameObjectWithTag("Player").transform;

       // warpPosition = new Vector3(PlayerT.position.x, PlayerT.position.y, SpawnPlane.position.z);

       
    }


    void LateUpdate()
    {
        if (warpPosition != Vector3.zero)
        {
            Debug.Log(PlayerT.position);
            GameObject.FindGameObjectWithTag("Player").transform.position = warpPosition;
            warpPosition = Vector3.zero;
            Debug.Log(PlayerT.position);

        }
    }
}
