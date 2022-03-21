using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    List<float> timesOfRounds;

    public GameObject enemyPrefab;
    public GameObject waveSpawnPointTopLeft;
    public GameObject waveSpawnPointTopRight;

    GameObject emptyWaveObject;
    GameObject emptyWaveObject2;

    GameManager gameManager;

    public float currentTime, endTime;

    // Start is called before the first frame update
    void Start()
    {
        timesOfRounds = new List<float>();

        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        endTime = Time.time;

        //check if no enemies left then spawn another random wave
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
        {
            //check for best time before next wave spawn
            endTime = endTime - currentTime;

            //add time to list and sort
            timesOfRounds.Add(endTime);
            timesOfRounds.Sort();

            //because the first value is always '0', the next value is always the best time
            if(timesOfRounds.Count > 1)
                gameManager.SetBestTime(timesOfRounds[1]);

            //spawn a new random wave
            var randomValue = Random.Range(1, 6);

            switch (randomValue)
            {
                case 1:
                    SpawnEnemyWave();
                    break;
                case 2:
                    SpawnEnemyWave2();
                    break;
                case 3:
                    SpawnEnemyWave3();
                    break;
                case 4:
                    SpawnEnemyWave4();
                    break;
                case 5:
                    SpawnEnemyWave5();
                    break;
                default:
                    Debug.Log("Switch error");
                    break;
            }

            currentTime = Time.time;
        }
    }



    //enemy wavebs
    void SpawnEnemyWave()
    {
        emptyWaveObject = new GameObject("Wave 1");

        //rows and columns for enemies
        int x = 7;
        int y = 4;

        for (int i = -x; i < x; i += 2)
            for (int j = 1; j < y; j++)
            {
                var enemy = Instantiate(enemyPrefab, new Vector3(i, j, -2), Quaternion.identity);
                enemy.transform.SetParent(emptyWaveObject.transform);
            }
        emptyWaveObject.transform.position += Vector3.up;
        emptyWaveObject.AddComponent<Enemy>();

    }
    void SpawnEnemyWave2()
    {
        emptyWaveObject = new GameObject("Wave 2");

        //instantiate enemies
        for (int i = 0; i < 5; i++)
        {
            var offset = new Vector3(-i, i, 0);
            var enemy = Instantiate(enemyPrefab, waveSpawnPointTopLeft.transform.position + offset, Quaternion.identity);
            enemy.transform.SetParent(emptyWaveObject.transform);
        }
        emptyWaveObject.AddComponent<EnemyDiagonal>();
    }

    void SpawnEnemyWave3()
    {
        emptyWaveObject = new GameObject("Wave 3");

        //instantiate enemies
        for (int i = 0; i < 5; i++)
        {
            var offset = new Vector3(i, i, 0);
            var enemy = Instantiate(enemyPrefab, waveSpawnPointTopRight.transform.position + offset, Quaternion.identity);
            enemy.transform.SetParent(emptyWaveObject.transform);
        }
        emptyWaveObject.AddComponent<EnemyDiagonalRight>();
    }

    void SpawnEnemyWave4()
    {
        StartCoroutine(Wave4());
    }

    IEnumerator Wave4()
    {
        for (int k = 0; k < 2; k++)
        {
            emptyWaveObject = new GameObject("Wave 4");

            //instantiate enemies
            for (int i = 0; i < 5; i++)
            {
                var offset = new Vector3(i, i, 0);
                var enemy = Instantiate(enemyPrefab, waveSpawnPointTopLeft.transform.position + offset, Quaternion.identity);
                enemy.transform.SetParent(emptyWaveObject.transform);
            }
            emptyWaveObject.AddComponent<EnemyDiagonal>();

            yield return new WaitForSeconds(2);

            emptyWaveObject2 = new GameObject("Wave 4.1");
            //instantiate enemies
            for (int i = 0; i < 5; i++)
            {
                var offset = new Vector3(-i, i, 0);
                var enemy = Instantiate(enemyPrefab, waveSpawnPointTopRight.transform.position + offset, Quaternion.identity);
                enemy.transform.SetParent(emptyWaveObject2.transform);
            }
            emptyWaveObject2.AddComponent<EnemyDiagonalRight>();
        }
    }

    void SpawnEnemyWave5()
    {
        StartCoroutine(Wave5());
    }

    IEnumerator Wave5()
    {
        for (int i = 0; i < 10; i++)
        {
            var x = Random.Range(-10, 10);
            var y = 5;
            var z = -2;

            var enemy = Instantiate(enemyPrefab, new Vector3(x, y, z), enemyPrefab.transform.rotation);
            enemy.AddComponent<RandomMoveDown>();
            yield return new WaitForSeconds(1);
        }
    }
}
