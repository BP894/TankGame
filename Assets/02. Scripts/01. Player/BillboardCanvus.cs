using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvus : MonoBehaviour
{
    private Transform tr;
    private Transform mainCameraTr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        mainCameraTr = Camera.main.transform;
    }
    private void Update()
    {
        tr.LookAt(mainCameraTr);
    }
}
