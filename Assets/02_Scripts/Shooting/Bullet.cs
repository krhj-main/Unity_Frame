using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;

        transform.position += dir * speed * Time.deltaTime;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DestroyZone"))
        {
            this.gameObject.SetActive(false);
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletListPool.Add(gameObject);
        }
    }
}
