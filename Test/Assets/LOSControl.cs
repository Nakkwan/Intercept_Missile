using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LOSControl : MonoBehaviour
{
    public float LOS_length;

    public GameObject M;

    private LineRenderer LOSDrawer;


    // Start is called before the first frame update
    void Start()
    {
        LOSDrawer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LOSDrawer.positionCount = 2;
        LOSDrawer.startWidth = 10;
        LOSDrawer.endWidth = 10;

        LOSDrawer.material.color = Color.red;
        LOSDrawer.SetPosition(0, M.transform.position);
        LOSDrawer.SetPosition(1, new Vector3(M.transform.position.x + LOS_length * Mathf.Sin((float)DataScript.LOS[DataScript.idx][0] * Mathf.PI / 180), M.transform.position.y + LOS_length * Mathf.Cos((float)DataScript.LOS[DataScript.idx][0] * Mathf.PI / 180), M.transform.position.z));
    }
}
