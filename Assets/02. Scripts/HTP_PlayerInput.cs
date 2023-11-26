using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTP_PlayerInput : MonoBehaviour
{
    public Camera playerCamera;

    [HideInInspector]
    public string moveAxisName = "Vertical";
    [HideInInspector]
    public string rotateAxisName = "Horizontal";
    [HideInInspector]
    public bool isFire = false;

    public float move { get; private set; }
    public float rotate { get; private set; }
    public bool fire { get; private set; }
    public Vector3 mousePosition { get; private set; }

    private void Update()
    {
        if(playerCamera.depth >= 1)
        {
            if (!isFire)
            {
                move = Input.GetAxis(moveAxisName);
                rotate = Input.GetAxis(rotateAxisName);
                fire = Input.GetMouseButtonDown(0);
            }
            else
            {
                move = 0.0f;
                rotate = 0.0f;
                fire = false;
            }
            mousePosition = Input.mousePosition;
        }
        else
        {
            move = 0.0f;
            rotate = 0.0f;
            fire = false;
        }
    }
}

