using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) ;
        transform.position += moveDir * speed * Time.deltaTime;
        //transform.Translate(moveDir * speed * Time.deltaTime);
        // ���� ������ �ڵ��̳�, �Լ��� ����ϴ��� �������� �����ϴ����� ����. ������ ����
    }
}
