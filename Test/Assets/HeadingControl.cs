﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class HeadingControl : MonoBehaviour
{
    string head_filename;
    public double time;
    public float Heading_length;
    int idx = 0;
    int interval;
    public GameObject M;

    List<List<double>> Heading;

    private LineRenderer HeadDrawer;


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
        this.head_filename = "Missile_Heading.txt";

        Heading = new List<List<double>>();
        HeadDrawer = GetComponent<LineRenderer>();
        interval = (int)(Time.deltaTime / time);

        csvRead(this.head_filename, this.Heading);
    }

    // Update is called once per frame
    void Update()
    {
        HeadDrawer.positionCount = 2;
        HeadDrawer.startWidth = 10;
        HeadDrawer.endWidth = 10;
        HeadDrawer.startColor = new Color(255, 0, 0, 0);
        HeadDrawer.endColor = new Color(255, 0, 0, 0);
        HeadDrawer.SetPosition(0, M.transform.position);
        HeadDrawer.SetPosition(1, new Vector3(M.transform.position.x + Heading_length * Mathf.Sin((float)Heading[idx][0] * Mathf.PI / 180), M.transform.position.y + Heading_length * Mathf.Cos((float)Heading[idx][0] * Mathf.PI / 180), M.transform.position.z));
        if (idx + interval < this.Heading.Count)
        {
            idx += interval;
        }
    }
}