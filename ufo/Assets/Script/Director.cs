﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : System.Object
{
    private static Director Instance;
    public SceneController scene { get; set; }
    public static Director GetInstance()
    {
        if (Instance == null)
        {
            Instance = new Director();
        }
        return Instance;
    }
}
