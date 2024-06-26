using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;

    float minTime = 0.1f;
    float maxTime = 0.2f;

    public float createTime;

    public GameObject enemyFactory;
    public int poolSize = 10;
    GameObject[] enemyPool;

    public List<GameObject> enemyListPool;

    [SerializeField] GameObject[] SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime,maxTime);

        enemyListPool = new List<GameObject>();
        enemyPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemys = Instantiate(enemyFactory);
            enemyListPool.Add(enemys);
            enemyListPool[i].SetActive(false);
        }
        /*
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemys = Instantiate(enemyFactory,transform.position,Quaternion.identity);
            enemyPool[i] = enemys;
            enemyPool[i].SetActive(false);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if (enemyListPool.Count > 0)
            {
                for (int i = 0; i < enemyListPool.Count; i++)
                {
                    GameObject enemys = enemyListPool[0];
                    enemys.SetActive(true);
                    enemyListPool.Remove(enemys);

                    int rand_Point = Random.Range(0, SpawnPoint.Length - 1);
                    enemys.transform.position = SpawnPoint[rand_Point].transform.position;
                    currentTime = 0;

                    createTime = Random.Range(minTime, maxTime);
                    break;
                }
            }
            /*
            for (int i = 0; i < poolSize; i++)
            {
                GameObject enemys = enemyPool[i];
                if (enemys.activeSelf == false)
                {
                    enemys.SetActive(true);

                    int rand_Point = Random.Range(0,SpawnPoint.Length-1);
                    enemys.transform.position = SpawnPoint[rand_Point].transform.position;
                    currentTime = 0;

                    createTime = Random.Range(minTime, maxTime);
                    break;
                }
            }
            */
        }

    }
}
