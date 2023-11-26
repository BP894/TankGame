using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtr : MonoBehaviour
{
    private Transform tr;
    private RaycastHit hit;

    public Transform camPivot;
    [HideInInspector]
    public PlayerInput playerInput;

    [HideInInspector]
    public float rotSpeed = 5.0f;
    

    private void Awake()
    {
        tr = GetComponent<Transform>();
        playerInput = GetComponentInParent<PlayerInput>();
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(playerInput.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            Vector3 relative = tr.InverseTransformPoint(hit.point);
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;

            tr.Rotate(0, angle * Time.deltaTime * rotSpeed, 0);
            
            //camPivot.Rotate(0, angle * Time.deltaTime * rotSpeed, 0);
        }
    }
}
