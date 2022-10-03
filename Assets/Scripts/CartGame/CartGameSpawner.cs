using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGameSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float objectAmount;
    List<GameObject> objects;
    public float maxTimer;
    public float Xzone;
    float timer;
    void Awake()
    {
        objects = new List<GameObject>();
        for(int i = 0;i < objectAmount; i++)
        {
            objects.Add(Instantiate(objectPrefab,Vector3.zero,Quaternion.identity,transform.parent));
        }
        timer = maxTimer;
    }
    void Update()
    {
        if(timer <= maxTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer > maxTimer)
        {
            Spawn();
            timer = 0;
        }
    }
    void Spawn()
    {
        GameObject objetOfThePool = null;
        for (int i = 0; i < objectAmount; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                objetOfThePool = objects[i];
                break;
            }
        }
        if (objetOfThePool != null)
        {
            objetOfThePool.SetActive(true);
            objetOfThePool.transform.position = transform.position + new Vector3(Random.Range(-Xzone, Xzone), 0, 0);
        }

    }
}
