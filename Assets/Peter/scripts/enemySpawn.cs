using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawntime = 0;

    private float time = 0;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += .02f;

        if (time > spawntime && Random.Range(0f, 1f) > .98)
        {
            Instantiate(enemyPrefab, this.gameObject.transform);
            time = 0;
            spawntime = (1 / GameObject.FindWithTag("DontDestroy").GetComponent<DifficultyScaling>().difficulty) - 1f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Instantiate(enemyPrefab, this.gameObject.transform);
        }
    }
}
