using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPool : MonoBehaviour
{
    public static CannonPool instance;
    private List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, new Vector3(0, 0, 0), objectToPool.transform.rotation);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    
}
