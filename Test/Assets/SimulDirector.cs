using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulDirector : MonoBehaviour
{
    GameObject Text_Collision;
    GameObject Text_Position;
    GameObject Text_LOS;
    GameObject Text_Acc;

    // Start is called before the first frame update
    void Start()
    {
        this.Text_Collision = GameObject.Find("Text_Collision");
        this.Text_Position = GameObject.Find("Text_Position");
        this.Text_LOS = GameObject.Find("Text_LOS");
        this.Text_Acc = GameObject.Find("Text_Acc");
    }

    // Update is called once per frame
    void Update()
    {
        this.Text_Position.GetComponent<Text>().text = "Missile: X = " + (DataScript.Missile_Pos[DataScript.idx][1]).ToString("F3") + ", Y = " + (DataScript.Missile_Pos[DataScript.idx][0] - 2000).ToString("F3") +
            "\nTarget: X = " + (DataScript.Target_Pos[DataScript.idx][1]).ToString("F3") + ", Y = " + (DataScript.Target_Pos[DataScript.idx][0] - 2000).ToString("F3");
        this.Text_LOS.GetComponent<Text>().text = "LOS = " + DataScript.LOS[DataScript.idx][0].ToString("F2");
        this.Text_Acc.GetComponent<Text>().text = "Acc = " + DataScript.ACC[DataScript.idx][0].ToString("F2");
    }

    public void PressReplayButton()
    {
        DataScript.idx = 0;
        this.Text_Collision.GetComponent<Text>().text = "";

    }
}
