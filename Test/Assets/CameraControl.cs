using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    GameObject Missile;
    GameObject Target;

    private Vector3 initial_pos;
    private Vector3 initial_euler;
    int flag;

    float mainSpeed = 100.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        this.Missile = GameObject.Find("Missile");
        this.Target = GameObject.Find("Target");
        initial_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        initial_euler = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            flag = 0;
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            flag = 1;
        }else if (Input.GetKeyDown(KeyCode.F3))
        {
            flag = 2;
        }else if (Input.GetKeyDown(KeyCode.F4))
        {
            flag = 3;
        }

        if (flag == 0)
        {
            transform.position = initial_pos;
            transform.eulerAngles = initial_euler;
        }
        else if (flag == 1)
        {
            float distance = (float)Math.Sqrt(Math.Pow(Missile.transform.position.x - Target.transform.position.x, 2) + Math.Pow(Missile.transform.position.y - Target.transform.position.y, 2));
            transform.position = new Vector3((Missile.transform.position.x + Target.transform.position.x) / 2,
                (Missile.transform.position.y + Target.transform.position.y) / 2,
                -distance / 2 - 100);
            transform.eulerAngles = initial_euler;
        }
        else if (flag == 2)
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
            //Mouse  camera angle done.  

            //Keyboard commands
            //float f = 0.0f;
            Vector3 p = GetBaseInput();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            { //If player wants to move on X and Z axis only
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            }
            else
            {
                transform.Translate(p);
            }

        }else if (flag == 3)
        {
            float distance = (float)Math.Sqrt(Math.Pow(Missile.transform.position.x - Target.transform.position.x, 2) + Math.Pow(Missile.transform.position.y - Target.transform.position.y, 2));
            transform.position = new Vector3(Missile.transform.position.x,
                Missile.transform.position.y,
                 -400);
            transform.eulerAngles = initial_euler;
        }
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-2, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(2, 0, 0);
        }
        return p_Velocity;
    }
}
