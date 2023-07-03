using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitsec());
    }
    IEnumerator waitsec()
    {
        yield return new WaitForSeconds(.1f);
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    private void OnLevelWasLoaded(int level)
    {
        StartCoroutine(waitsec());

    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            this.gameObject.transform.position = new Vector3(0, 5, player.transform.position.z - 3);

        }
    }
}
