using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AccControl : MonoBehaviour
{
    string acc_filename;
    public double time;
    int idx = 0;
    int interval;
    float G = 9.8f;

    public GameObject M;
    public GameObject L;

    List<List<double>> ACC;

    private LineRenderer ACCDrawer;

    void csvRead(string filename, List<List<double>> output)
    {
        int n = 0;
        output.Clear();

        StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + '\\' + filename);

        while (!sr.EndOfStream)
        {
            string s = sr.ReadLine();
            string[] data = s.Split(',');

            output.Add(new List<double>());
            for (int i = 0; i < data.Length; i++)
            {
                output[n].Add(Convert.ToDouble(data[i]));
            }
            n++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.acc_filename = "Line_of_Sight.txt";
        ACC = new List<List<double>>();
        //GameObject M = Instantiate(Missile) as GameObject;
        ACCDrawer = GetComponent<LineRenderer>();
        interval = (int)(Time.deltaTime / time);

        csvRead(this.acc_filename, this.ACC);
    }

    // Update is called once per frame
    void Update()
    {
        ACCDrawer.positionCount = 2;
        ACCDrawer.startWidth = 10;
        ACCDrawer.endWidth = 10;
        //LOSDrawer.startColor = new Color(0, 255, 0, 0);
        //LOSDrawer.endColor = new Color(0, 255, 0, 0);
        Vector3[] L_pos;
        L_pos = new Vector3[2];
        L.GetComponent<LineRenderer>().GetPositions(L_pos);
        ACCDrawer.material.color = Color.green;
        ACCDrawer.SetPosition(0, L_pos[0]);

        Vector3 dist = L_pos[1] - L_pos[0];
        
        ACCDrawer.SetPosition(1, new Vector3(L_pos[0].x - (float)ACC[idx][0] / G * dist.y, L_pos[0].y + (float)ACC[idx][0] / G * dist.x, L_pos[0].z));

        if (idx + interval < this.ACC.Count)
        {
            idx += interval;
        }
    }
}
