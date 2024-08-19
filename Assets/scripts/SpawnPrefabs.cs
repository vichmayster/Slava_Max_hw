using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPrefabs : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float WaitTimeToSpawn = 1.0f;
    [SerializeField] int amountToSpawn;
    [SerializeField] GameObject spawn_a;
    [SerializeField] GameObject spawn_b;
    [SerializeField] GameObject spawn_c;
    [SerializeField] GameObject spawn_d;
    [SerializeField] GameObject spawn_e;
    [SerializeField] GameObject spawn_f;
    [SerializeField] GameObject spawn_g;
    [SerializeField] GameObject spawn_h;
    [SerializeField] Vector2 waitTimeRandom = new Vector2 (0, 0.6f);
    private GameObject[] spawnPoints;
    [SerializeField] float impulseForce = 10f;
    // Start is called before the first frame update
    void Start()
    {

        spawnPoints = new GameObject[] { spawn_a, spawn_b, spawn_c, spawn_d, spawn_e, spawn_f, spawn_g, spawn_h };

        if (prefab == null)
            Debug.LogError("Prefab is missing");
        if (spawn_a == null)
            Debug.LogError("Missing Spawn point a");
        if (spawn_b == null)
            Debug.LogError("Missing Spawn point b");
        if (spawn_c == null)
            Debug.LogError("Missing Spawn point c");
        if (spawn_d == null)
            Debug.LogError("Missing Spawn point d");
        if (spawn_e == null)
            Debug.LogError("Missing Spawn point e");
        if (spawn_f == null)
            Debug.LogError("Missing Spawn point f");
        if (spawn_g == null)
            Debug.LogError("Missing Spawn point g");
        if (spawn_h == null)
            Debug.LogError("Missing Spawn point h");
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
