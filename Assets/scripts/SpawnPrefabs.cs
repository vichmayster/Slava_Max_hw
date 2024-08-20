using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPrefabs : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float WaitTimeToSpawn = 1.0f;
    [SerializeField] int amountToSpawn;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] Vector2 waitTimeRandom = new Vector2 (0, 0.6f);
    [SerializeField] float impulseForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            yield return new WaitForSeconds(WaitTimeToSpawn - Random.Range(waitTimeRandom.x, waitTimeRandom.y));
            GameObject randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject spawnedPrefab = Instantiate(prefab, randomSpawnPoint.transform.position, Quaternion.identity);

          
            Rigidbody2D rb = spawnedPrefab.GetComponent<Rigidbody2D>();
            
            //Converting randomSpawnPoint -> transformation -> rotation -> axis z, to angle of impulse
            float angle = randomSpawnPoint.transform.rotation.eulerAngles.z + 90;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            rb.AddForce(direction * impulseForce, ForceMode2D.Impulse);
          
           
        }
    }
}
