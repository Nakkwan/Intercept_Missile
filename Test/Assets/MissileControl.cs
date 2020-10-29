using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;
using UnityEditor;

public class MissileControl : MonoBehaviour
{
    public float HEDEG;
    private Vector3 initial_euler;


    // Start is called before the first frame update
    void Start()
    {
        initial_euler = transform.eulerAngles;
        Tools.pivotMode = PivotMode.Center;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)DataScript.Missile_Pos[DataScript.idx][1], (float)DataScript.Missile_Pos[DataScript.idx][0] - 2000, 0);
        transform.eulerAngles = new Vector3(initial_euler.x, initial_euler.y, -(float)DataScript.LOS[DataScript.idx][0]);
    }
}
