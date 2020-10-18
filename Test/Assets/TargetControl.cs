using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TargetControl : MonoBehaviour
{
    public double G;
    //public float ini_vel;
    public float HEDEG;
    public double time;
    string filename;
    int idx;
    int interval;
    List<List<double>> Target_Pos;

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
            output[n].Add(Convert.ToDouble(data[0]));
            output[n].Add(Convert.ToDouble(data[1]));
            n++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.filename = "Target_Traj.txt";
        interval = (int)(Time.deltaTime / time);
        this.idx = 0;
        Target_Pos = new List<List<double>>();

        //this.rigid.velocity = new Vector3(ini_vel * Mathf.Sin(HEDEG), ini_vel * Mathf.Cos(HEDEG), 0);

        csvRead(this.filename, this.Target_Pos);

        Debug.Log(this.Target_Pos.Count);
        Debug.Log(this.Target_Pos[0].Count);
        Debug.Log((float)Target_Pos[idx][0]);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)Target_Pos[idx][1], (float)Target_Pos[idx][0] - 2000, 0);
        //transform.Translate((float)(Missile_Pos[idx][1] - Missile_Pos[idx - interval][1]), (float)(Missile_Pos[idx][0] - Missile_Pos[idx - interval][0]), 0);
        if (idx + interval < this.Target_Pos.Count)
        {
            idx += interval;
        }
    }
}
