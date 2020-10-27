using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Go : MonoBehaviour
{

/*    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use(drag and drop, done) for regular keyboard layout
   wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.So camera doesn't gain any height*/


    float mainSpeed = 70.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    private float totalRun = 1.0f;
    public bool ActiveCorpuses = false;


    public void Start()
    {
        Debug.Log("Start!");
    }
    

    void Update()
    {

        /*if (!ActiveCorpuses)
        {
            toggleMapToCamera(!ActiveCorpuses);
            ActiveCorpuses = !false;
        }*/
       /* lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;*/
        //Mouse  camera angle done.  

        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput();


        if (Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
       
        transform.Translate(p);
        newPosition.z = transform.position.z;
        newPosition.x = transform.position.x;
        transform.position = newPosition;

    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();

        if (Input.GetKey(KeyCode.W))
                p_Velocity += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.S))
                p_Velocity += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.A))
                p_Velocity += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D))
                p_Velocity += new Vector3(1, 0, 0);

        return p_Velocity;
    }
    public void toggleMapToCamera(int flag)
    {
        switch (flag)
        {
            case 0:
                {
                    transform.position -= new Vector3(0, 160, 0);
                    transform.rotation = Quaternion.Euler(15, 90f, 0f);
                }break;
            case 1:
                {
                    transform.position += new Vector3(0, 160, 0);
                    transform.rotation = Quaternion.Euler(75f, 90f, 0f);
                }break;
        }
        
    }

}