using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Vector3 dir;

    [SerializeField] GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
        

        int randValue = Random.Range(0, 10);

        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("DestroyZone"))
        {
            Destroy(collision.gameObject);
        }
        GameObject fx = Instantiate(effect,transform.position,transform.rotation);
        Destroy(fx,1f);
        Destroy(this.gameObject);
    }
}
