using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TargetControl : MonoBehaviour
{
    public double G;
    public float HEDEG;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)DataScript.Target_Pos[DataScript.idx][1], (float)DataScript.Target_Pos[DataScript.idx][0] - 2000, 0);
    }
}
