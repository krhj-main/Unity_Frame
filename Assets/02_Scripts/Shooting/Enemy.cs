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
            this.gameObject.SetActive(false);
            EnemyManager my = GameObject.Find("EnemySpawner").GetComponent<EnemyManager>();
            my.enemyListPool.Add(this.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("DestroyZone"))
        {
            this.gameObject.SetActive(false);
            EnemyManager my = GameObject.Find("EnemySpawner").GetComponent<EnemyManager>();
            my.enemyListPool.Add(this.gameObject);
        }

        /*
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            collision.gameObject.SetActive(false);
        }
        */
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletListPool.Add(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        GameObject fx = Instantiate(effect, transform.position, transform.rotation);
        Destroy(fx, 0.5f);
        ScoreUI.Instance.CurrentScore += 10;
    }
}
