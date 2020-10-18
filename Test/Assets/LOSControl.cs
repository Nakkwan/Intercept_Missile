using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LOSControl : MonoBehaviour
{
    string los_filename;
    public double time;
    public float LOS_length;
    int idx = 0;
    int interval;

    public GameObject M;

    List<List<double>> LOS;

    private LineRenderer LOSDrawer;


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
        this.los_filename = "Line_of_Sight.txt";
        LOS = new List<List<double>>();
        //GameObject M = Instantiate(Missile) as GameObject;
        LOSDrawer = GetComponent<LineRenderer>();
        interval = (int)(Time.deltaTime / time);

        csvRead(this.los_filename, this.LOS);
    }

    // Update is called once per frame
    void Update()
    {
        LOSDrawer.positionCount = 2;
        LOSDrawer.startWidth = 10;
        LOSDrawer.endWidth = 10;
        LOSDrawer.startColor = new Color(0, 255, 0, 0);
        LOSDrawer.endColor = new Color(0, 255, 0, 0);
        LOSDrawer.SetPosition(0, M.transform.position);
        LOSDrawer.SetPosition(1, new Vector3(M.transform.position.x + LOS_length * Mathf.Sin((float)LOS[idx][0] * Mathf.PI / 180), M.transform.position.y + LOS_length * Mathf.Cos((float)LOS[idx][0] * Mathf.PI / 180), M.transform.position.z));
        if (idx + interval < this.LOS.Count)
        {
            idx += interval;
        }
    }
}
