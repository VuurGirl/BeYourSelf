using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : Singleton<GameManeger>
{
    public GameObject Player;

    void Awake()
    {
        Instance = this;

    }
}
