using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float maxSpawnInterval;

    [SerializeField]
    float minSpawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;

    float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        PreSpawnClouds();
       spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("AttemptSpawn", spawnInterval);
    }

 void SpawnCloud(Vector3 startPos)
    {

        int randomIndex = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);


        float startY = Random.Range(startPos.y - 14f, startPos.y + 2f);
        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float scale = Random.Range(0.5f, 2f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = Random.Range(0.5f, 1.5f);
        cloud.GetComponent<CloudMovement>().StartFloating(speed, endPoint.transform.position.x);


    }


    void AttemptSpawn()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

        SpawnCloud(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }

    void PreSpawnClouds()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 10);
            SpawnCloud(spawnPos);
        }
    }
}
