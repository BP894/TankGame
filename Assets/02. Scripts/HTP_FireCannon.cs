using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTP_FireCannon : MonoBehaviour
{
    public GameObject cannon;
    public Transform firePos;

    private HTP_PlayerInput playerInput;
    private void Awake()
    {
        playerInput = GetComponent<HTP_PlayerInput>();
    }
    private void Update()
    {
        if (playerInput.fire)
        {
            Fire();
        }
    }
    void Fire()
    {
        Instantiate(cannon, firePos.position, firePos.rotation);
    }
}
