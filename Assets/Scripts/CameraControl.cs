﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public Transform bg1;

    public Transform bg2;

    private float size;

    private Vector3 cameraTargetPos = new Vector3();    
    private Vector3 bgTargetPos = new Vector3();    
    private Vector3 bg2TargetPos = new Vector3();   


    // Start is called before the first frame update
    void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera
        Vector3 targetPos = SetPos(cameraTargetPos, transform.position.x, target.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);

        //background
        if(transform.position.y >= bg2.position.y)
        {
            bg1.position = SetPos(cameraTargetPos, bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBg();
        }

        if(transform.position.y< bg1.position.y)
        {
            bg2.position = SetPos(cameraTargetPos, bg2.position.x, bg1.position.y - size, bg2.position.z);
            SwitchBg();
        }
    }

    private void SwitchBg()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

    private Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
