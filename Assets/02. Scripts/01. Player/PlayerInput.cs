using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public string moveAxisName = "Vertical";
    [HideInInspector]
    public string rotateAxisName = "Horizontal";
    [HideInInspector]
    public bool isFire = false;
    bool isDead;
    public float move { get; private set; }
    public float rotate { get; private set; }
    public bool fire { get; private set; }
    public Vector3 mousePosition { get; private set; }
    
    private void Update()
    {
        isDead = GetComponent<TankDamage>().isDead;
        if (!isDead)
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
    }
}
