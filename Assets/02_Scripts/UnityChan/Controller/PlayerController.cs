using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 3f;

    //InputManager _input = new InputManager();
    // Start is called before the first frame update
    void Start()
    {
        //_input.KeyAction = OnKeyBoard;
        UnityManagers.Input.KeyAction -= OnKeyBoard;
        UnityManagers.Input.KeyAction += OnKeyBoard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.Translate(Vector3.forward * Time.unscaledDeltaTime * _speed);
            // transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            // transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
            // transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            // transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
            // transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
            // transform.position += Vector3.left * Time.deltaTime * _speed;
        }
    }
}
