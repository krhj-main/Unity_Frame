using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefabs;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    static ObjectPool instance;
    public static ObjectPool Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag,objectpool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            //널검사, 해당 키값에 해당하는 밸류값이 없다.
            return null;
        }

        GameObject objectspawn = poolDictionary[tag].Dequeue();

        objectspawn.SetActive(true);
        objectspawn.transform.position = position;
        objectspawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectspawn);

        return objectspawn;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
