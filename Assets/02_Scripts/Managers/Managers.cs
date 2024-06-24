using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    // 유일성이 보장됨
    // 유일한 매니저를 가지고온다


    // 프로퍼티 읽기전용  set을 쓰면 쓰기가 가능
    // s_instance 값이 바뀌면 안되므로 get만 사용함
    public static Managers Instance
    {
        get 
        {
            Init();

            return s_instance;
        }
    }

    private void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject
                {
                    name = "@Managers"
                };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
