﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public int x;
    public string text;

    // Start is called before the first frame update
    void Start()
    {
        if (x>0)
        {
            Debug.Log("x ist größer als null");
        }
        else
        {s
            Debug.Log("x ist kleiner als null");
        }

        if (text == "ALE")
        {
            Debug.Log("In der text Variable steht ALE");
        }
        else
        {
            Debug.Log("In der text Variable steht  etwas anderes");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
