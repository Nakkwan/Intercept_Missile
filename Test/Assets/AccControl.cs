using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AccControl : MonoBehaviour
{
    public GameObject M;
    public GameObject L;

    private LineRenderer ACCDrawer;

    // Start is called before the first frame update
    void Start()
    {
        ACCDrawer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ACCDrawer.positionCount = 2;
        ACCDrawer.startWidth = 10;
        ACCDrawer.endWidth = 10;
        Vector3[] L_pos;
        L_pos = new Vector3[2];
        L.GetComponent<LineRenderer>().GetPositions(L_pos);
        ACCDrawer.material.color = Color.yellow;
        ACCDrawer.SetPosition(0, L_pos[0]);

        Vector3 dist = L_pos[1] - L_pos[0];
        
        ACCDrawer.SetPosition(1, new Vector3(L_pos[0].x - (float)DataScript.ACC[DataScript.idx][0] / DataScript.G * dist.y, L_pos[0].y + (float)DataScript.ACC[DataScript.idx][0] / DataScript.G * dist.x, L_pos[0].z));
    }
}
