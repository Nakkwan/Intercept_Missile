using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;

public class MissileControl : MonoBehaviour
{

    //public double G;
    //public float ini_vel;
    public float HEDEG;
    private Vector3 initial_euler;
    /*public double time;
    string pos_filename;
    int idx;
    int interval;
    List<List<double>> Missile_Pos;*/


    // Start is called before the first frame update
    void Start()
    {
        initial_euler = transform.eulerAngles;
        //this.pos_filename = "Missile_Traj.txt";
        //interval = (int)(Time.deltaTime / time);
        //this.idx = 0;
        //Missile_Pos = new List<List<double>>();

        //this.rigid.velocity = new Vector3(ini_vel * Mathf.Sin(HEDEG), ini_vel * Mathf.Cos(HEDEG), 0);

        /*        csvRead(this.pos_filename, this.Missile_Pos);

                Debug.Log(this.Missile_Pos.Count);
                Debug.Log(this.Missile_Pos[0].Count);
                Debug.Log((float)Missile_Pos[idx][0]);*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)DataScript.Missile_Pos[DataScript.idx][1], (float)DataScript.Missile_Pos[DataScript.idx][0] - 2000, 0);
        transform.eulerAngles = new Vector3(initial_euler.x, initial_euler.y, -(float)DataScript.LOS[DataScript.idx][0]);
        //transform.Translate((float)(Missile_Pos[idx][1] - Missile_Pos[idx - interval][1]), (float)(Missile_Pos[idx][0] - Missile_Pos[idx - interval][0]), 0);

/*        if (idx + interval < this.Missile_Pos.Count)
        {
            idx += interval;
        }*/
    }

/*    private void OnTriggerStay(Collider other)
    {
        GameObject Text_Col = GameObject.Find("Text_Collision");
        Text_Col.GetComponent<SimulDirector>().Intercept();
    }*/

}
