﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                    Destroy(this.gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
