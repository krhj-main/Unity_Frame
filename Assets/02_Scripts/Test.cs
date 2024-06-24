using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int hp = 100;
    const int maxHp = 100;

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;

            if (hp > maxHp)
            {
                hp = maxHp;
                Debug.Log("hp가 최대 hp를 넘음 ");
            }
            else if (hp <= 0)
            {
                OnDie();
            }
            Debug.Log("현재  hp : " + hp);
        }
    }

    void OnDie()
    {
        Debug.Log("hp가 0 아래로 떨어짐");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
