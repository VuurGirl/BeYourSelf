using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScoreManager : Singleton<ScoreManager>
{

    [NonSerialized] public int AnimalCount = 0;
    [NonSerialized] public int CoinCount = 0;



    void Awake()
    {
        Instance = this;

    }
}

