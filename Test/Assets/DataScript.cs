using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using System;
using System.IO;

public class DataScript : MonoBehaviour
{

    public static double t;
    public static int idx;
    int interval;
    public static float G;
    public double time;

    public static List<List<double>> Target_Pos;
    public static List<List<double>> Missile_Pos;
    public static List<List<double>> Heading;
    public static List<List<double>> ACC;
    public static List<List<double>> LOS;

    string T_filename;
    string M_filename;
    string L_filename;
    string H_filename;
    string A_filename;

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
        interval = (int)(Time.deltaTime / time);
        T_filename = "Target_Traj.txt";
        M_filename = "Missile_Traj.txt";
        H_filename = "Missile_Heading.txt";
        A_filename = "Line_of_Sight.txt";
        L_filename = "Line_of_Sight.txt";
        idx = 0;
        G = 9.8f;

        Target_Pos = new List<List<double>>();
        Missile_Pos = new List<List<double>>();
        Heading = new List<List<double>>();
        ACC = new List<List<double>>();
        LOS = new List<List<double>>();

        csvRead(this.T_filename, Target_Pos);
        csvRead(this.M_filename, Missile_Pos);
        csvRead(this.H_filename, Heading);
        csvRead(this.A_filename, ACC);
        csvRead(this.L_filename, LOS);
    }

    // Update is called once per frame
    void Update()
    {
        if (idx + interval < LOS.Count && idx + interval < Target_Pos.Count && idx + interval < Missile_Pos.Count && idx + interval < Heading.Count && idx + interval < ACC.Count)
        {
            idx += interval;
        }
    }
}
