using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip fireSound;

    public GameObject cannon;
    public Transform firePos;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(playerInput.fire)
        {
            audio.PlayOneShot(fireSound);
            Fire();
        }
    }
    void Fire()
    {
        Instantiate(cannon, firePos.position, firePos.rotation);
    }
}
