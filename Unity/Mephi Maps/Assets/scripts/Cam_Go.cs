using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Go : MonoBehaviour
{

    float mainSpeed = 70.0f; //regular speed
    float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    private float totalRun = 1.0f;
    public bool ActiveCorpuses = false;
    public Vector3 StartCameraPosition = new Vector3(-304, 139, 535);


    public void Start()
    {
        gameObject.transform.position = StartCameraPosition;
        Debug.Log("Start!");
    }
    

    void Update()
    {
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