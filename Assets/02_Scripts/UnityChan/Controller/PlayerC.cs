using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3 (Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        transform.position += axis* Time.deltaTime * speed; 
    }
}
