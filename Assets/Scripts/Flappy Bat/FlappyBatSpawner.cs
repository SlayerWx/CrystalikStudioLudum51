using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBatSpawner : MonoBehaviour
{
    [SerializeField] private float time = 2;
    [SerializeField] private float yClamp = 1.5f;
    public GameObject coinPrefab;
    public float minDistance;
    public float firstSpawnOffsetX;
    public float firstSpawnOffsetX2;
    public GameObject skyPrefab;
    public GameObject groundPrefab;
    
    private float elapsedTime;

    void Start()
    {

        float offsetY = Random.Range(-yClamp, yClamp);
        if (offsetY > 0)
        {
            Vector2 pos = new Vector2(transform.position.x - firstSpawnOffsetX, transform.position.y + minDistance + offsetY);

            Instantiate(skyPrefab, pos, Quaternion.identity, transform);
        }
        else
        {
            Vector2 pos = new Vector2(transform.position.x - firstSpawnOffsetX, transform.position.y - minDistance + offsetY);

            Instantiate(groundPrefab, pos, Quaternion.identity, transform);
        }

        float offsetY2 = Random.Range(-yClamp, yClamp);
        if (offsetY2 > 0)
        {
            Vector2 pos = new Vector2(transform.position.x - firstSpawnOffsetX2, transform.position.y + minDistance + offsetY2);

            Instantiate(skyPrefab, pos, Quaternion.identity, transform);
        }
        else
        {
            Vector2 pos = new Vector2(transform.position.x - firstSpawnOffsetX2, transform.position.y - minDistance + offsetY2);

            Instantiate(groundPrefab, pos, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > time)
        {
            SpawnObject();
            elapsedTime = 0f;
        }

    }
    private void SpawnObject()
    {
        float offsetY = Random.Range(-yClamp, yClamp);
        if (offsetY > 0)
        { 
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + minDistance + offsetY);

            Instantiate(skyPrefab, pos, Quaternion.identity, transform);
            GameObject aux = Instantiate(coinPrefab, pos -  (Vector2.up * 5f), Quaternion.identity, transform);
            aux.SetActive(true);

        }
        else
        { 
            Vector2 pos = new Vector2(transform.position.x, transform.position.y - minDistance + offsetY);
        
            Instantiate(groundPrefab, pos, Quaternion.identity, transform);
            GameObject aux = Instantiate(coinPrefab, pos + (Vector2.up * 5f), Quaternion.identity, transform);
            aux.SetActive(true);

        }
    }
}
