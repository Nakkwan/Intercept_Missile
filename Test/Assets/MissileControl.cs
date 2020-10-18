using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;

public class MissileControl : MonoBehaviour
{

    public double G;
    //public float ini_vel;
    public float HEDEG;
    public double time;
    string pos_filename;
    int idx;
    int interval;
    List<List<double>> Missile_Pos;

    private LineRenderer LineDrawer;

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
        this.pos_filename = "Missile_Traj.txt";
        interval = (int)(Time.deltaTime / time);
        this.idx = 0;
        Missile_Pos = new List<List<double>>();
        LineDrawer = GetComponent<LineRenderer>();

        //this.rigid.velocity = new Vector3(ini_vel * Mathf.Sin(HEDEG), ini_vel * Mathf.Cos(HEDEG), 0);

        csvRead(this.pos_filename, this.Missile_Pos);

        Debug.Log(this.Missile_Pos.Count);
        Debug.Log(this.Missile_Pos[0].Count);
        Debug.Log((float)Missile_Pos[idx][0]);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)Missile_Pos[idx][1], (float)Missile_Pos[idx][0] - 2000, 0);
        //transform.Translate((float)(Missile_Pos[idx][1] - Missile_Pos[idx - interval][1]), (float)(Missile_Pos[idx][0] - Missile_Pos[idx - interval][0]), 0);

        if (idx + interval < this.Missile_Pos.Count)
        {
            idx += interval;
        }
    }
}
