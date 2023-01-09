using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    public Transform storage;
    public GameObject obj;
    public List<GameObject> pooledObjs = new List<GameObject>();
    public int poolingCount;
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        // disable here to prevent OnEnable executing when instatiating for pool.
        // we want OnEnable to execute only when obj is REALLY used in game.
        obj.SetActive(false);

        GameObject tempObj;
        for (int i = 0; i < poolingCount; i++)
        {
            tempObj = Instantiate(obj, storage);
            pooledObjs.Add(tempObj);
        }
    }

    public GameObject getPooledObj()
    {
        for (int i = 0; i < poolingCount; i++ )
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }
        Debug.LogError("Run out of pooled objects in ObjectPooling/getPooledObj");
        return null;
    }
}
