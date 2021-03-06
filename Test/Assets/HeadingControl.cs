﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class HeadingControl : MonoBehaviour
{
    public float Heading_length;
    public GameObject M;

    private LineRenderer HeadDrawer;


    // Start is called before the first frame update
    void Start()
    {
        HeadDrawer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        HeadDrawer.positionCount = 2;
        HeadDrawer.startWidth = 10;
        HeadDrawer.endWidth = 10;
        HeadDrawer.material.color = Color.blue;
        HeadDrawer.SetPosition(0, M.transform.position);
        HeadDrawer.SetPosition(1, new Vector3(M.transform.position.x + Heading_length * Mathf.Sin((float)DataScript.Heading[DataScript.idx][0] * Mathf.PI / 180), M.transform.position.y + Heading_length * Mathf.Cos((float)DataScript.Heading[DataScript.idx][0] * Mathf.PI / 180), M.transform.position.z));
    }
}
