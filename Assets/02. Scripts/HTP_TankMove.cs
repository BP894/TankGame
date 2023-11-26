using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class HTP_TankMove : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    [HideInInspector]
    public float rotSpeed = 50.0f;

    public GameObject F_WheelLeft;
    public GameObject F_WheelRight;
    public GameObject B_WheelLeft;
    public GameObject B_WheelRight;

    public Transform camPivot;
    [HideInInspector]
    public HTP_PlayerInput playerInput = null;
    private Rigidbody rBody;
    private Transform tr;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        playerInput = GetComponent<HTP_PlayerInput>();

        Camera.main.GetComponent<SmoothFollow>().target = camPivot;
        rBody.centerOfMass = new Vector3(0f, -0.5f, 0.0f);
    }
    private void Update()
    {
        tr.Translate(Vector3.forward * playerInput.move * moveSpeed * Time.deltaTime);
        tr.Rotate(Vector3.up * playerInput.rotate * rotSpeed * Time.deltaTime);

        F_WheelLeft.transform.Rotate(Vector3.right * playerInput.move * moveSpeed * Time.deltaTime * 500);
        F_WheelRight.transform.Rotate(Vector3.right * playerInput.move * moveSpeed * Time.deltaTime * 500);
        B_WheelLeft.transform.Rotate(Vector3.right * playerInput.move * moveSpeed * Time.deltaTime * 500);
        B_WheelRight.transform.Rotate(Vector3.right * playerInput.move * moveSpeed * Time.deltaTime * 500);
    }
}
