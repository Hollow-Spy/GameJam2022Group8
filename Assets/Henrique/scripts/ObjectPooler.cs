using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
   public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {

        DontDestroyOnLoad(gameObject);

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i=0;i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                DontDestroyOnLoad(obj);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);

        }
    }

    //god please breakey

    public GameObject SpawnFromPool (string tag, Vector3 Position, Quaternion rotation)
    {

        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("pool with tag" + tag + "dosent exist");
            return null;
        }

     GameObject objecttoSpawn = poolDictionary[tag].Dequeue();
        objecttoSpawn.SetActive(true);
        objecttoSpawn.transform.position = Position;
        objecttoSpawn.transform.rotation = rotation;

        IPoolerObject pooledObj = objecttoSpawn.GetComponent<IPoolerObject>();

        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objecttoSpawn);
        return objecttoSpawn;
    }
}
