using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform knife;
    public Vector3 offset;
    public float speed = 0.2f;
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;
    void Start()
    {
        StartCoroutine(SpawnFruits());


    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(1f);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            int fruitIndex = Random.Range(0, fruitPrefabs.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject fruitPrefab = fruitPrefabs[fruitIndex];

            Instantiate(fruitPrefab, spawnPoint.position, fruitPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = new Vector3(knife.position.x + offset.x, 6, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPosition;
    }

}
