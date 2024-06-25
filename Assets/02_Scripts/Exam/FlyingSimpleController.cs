using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSimpleController : MonoBehaviour
{

    public KeyCode m_PitchPlus = KeyCode.W,
        m_PitchMinus = KeyCode.S,

        m_YawPlus = KeyCode.A,
        m_YawMinus = KeyCode.D,

        m_RollPlus = KeyCode.Q,
        m_RollMinus = KeyCode.E,

        m_Move = KeyCode.Space,
        m_SpeedUp = KeyCode.PageUp,
        m_SpeedDown = KeyCode.PageDown;


    public float m_Speed = 10,
        m_MaxSpeed = 200,
        m_ChangeStep = 10,
        m_RotateSpeed = 30;

    bool m_IsMove = false;




    private void FixedUpdate()
    {
        Move();
    }
    // Start is called before the first frame update
    void Start()
    {
        //dir = Quaternion.Euler(-90, -90, -90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Move()
    {
        if (Input.GetKey(m_Move))
        {
            m_IsMove = !m_IsMove;
        }

        if (m_IsMove == true)
        {
            transform.Translate(Vector3.down * m_Speed * Time.deltaTime);
            // x 축 회전
            if (Input.GetKey(m_PitchPlus))
            {
                transform.Rotate(1,0,0);
            }
            else if (Input.GetKey(m_PitchMinus))
            {
                transform.Rotate(-1, 0, 0);
            }

            // y축 회전
            if (Input.GetKey(m_YawPlus))
            {
                transform.Rotate(0, 1, 0);
            }
            else if (Input.GetKey(m_YawMinus))
            {
                transform.Rotate(0, -1, 0);
            }


            // z 축 회전
            if (Input.GetKey(m_RollPlus))
            {
                transform.Rotate(0, 0, 1);
            }
            else if (Input.GetKey(m_RollMinus))
            {
                transform.Rotate(0, 0, -1);
            }


            if (Input.GetKey(m_SpeedUp))
            {
                m_Speed += m_ChangeStep;
            }
            if (Input.GetKey(m_SpeedDown))
            {
                m_Speed -= m_ChangeStep;
            }

            if (m_Speed > m_MaxSpeed)
            {
                m_Speed = m_MaxSpeed;
            }
            else if (m_Speed <= 0)
            {
                m_Speed = 0;
            }
        }
    }
}
