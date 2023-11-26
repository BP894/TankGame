using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTP_KeyGuide : MonoBehaviour
{
    private HTP_PlayerInput playerInput;

    public Image wKey;
    public GameObject wKeyPanel;
    public Image sKey;
    public GameObject sKeyPanel;
    public Image aKey;
    public GameObject aKeyPanel;
    public Image dKey;
    public GameObject dKeyPanel;

    private Camera playerCamera;

    private void Update()
    {
        playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerInput = FindObjectOfType<HTP_PlayerInput>();
        if(playerCamera.depth >= 1 && !playerInput.isFire)
        {
            KeyGuide();
        }
        else
        {
            wKeyPanel.SetActive(false);
            sKeyPanel.SetActive(false);
            aKeyPanel.SetActive(false);
            dKeyPanel.SetActive(false);
        }
    }
    private void KeyGuide()
    {
        if (Input.GetKey(KeyCode.W))
        {
            wKeyPanel.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            wKeyPanel.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            sKeyPanel.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            sKeyPanel.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            aKeyPanel.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            aKeyPanel.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dKeyPanel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            dKeyPanel.SetActive(false);
        }
        
    }
}
