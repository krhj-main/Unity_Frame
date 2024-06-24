using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public string nickname { get; set; }
    public int level { get; set; }
    public int hp{ get; set; }
    public int mp{ get; set; }
}

public class Player : MonoBehaviour
{
    PlayerInfo playerinfo;
    // Start is called before the first frame update
    void Start()
    {
        Managers mg = Managers.Instance;

        playerinfo.nickname = "Simbble";
        playerinfo.level = 20;
        playerinfo.hp = 100;
        playerinfo.mp = 20;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
