using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManagers : MonoBehaviour
{
    static UnityManagers U_instance;
    static UnityManagers U_Instance
    {
        get { return U_instance; }
    }

    InputManager _input = new InputManager();

    public static InputManager Input
    {
        get { return U_Instance._input; }
    }

    private void Awake()
    {
        if (U_instance == null)
        {
            U_instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
    }
}
