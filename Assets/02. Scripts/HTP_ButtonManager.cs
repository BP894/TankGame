using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HTP_ButtonManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip buttonClick;

    public Camera howToControlCamera;
    public GameObject keyPanel;

    public Camera myTankCamera;
    public Camera myBulletCamera;
    public Transform myTankCameraRotation;
    public Transform myBulletCameraRotation;
    public GameObject playerStatusPanel;

    public Camera enemyTank01Camera;
    public Camera enemyTank02Camera;
    public Camera enemyBulletCamera;
    public Transform enemyTank01CameraRotation;
    public Transform enemyTank02CameraRotation;
    public Transform enemyBulletCameraRotation;
    public GameObject enemyStatusPanel;

    public Camera heartCamera;
    public Camera jewelCamera;
    public Camera keyCamera;
    public Transform heartCameraRotation;
    public Transform jewelCameraRotation;
    public Transform keyCameraRotation;
    public GameObject itemStatusPanel;

    public GameObject HowToPlayPanel;
    public void Start()
    {
        ViewReset();
        audio = GetComponent<AudioSource>();
    }
    public void HowToControl()
    {
        ViewReset();

        audio.PlayOneShot(buttonClick);
        howToControlCamera.depth = 11;
        keyPanel.SetActive(true);

    }
    public void MyStatus()
    {
        ViewReset();

        audio.PlayOneShot(buttonClick);
        myTankCamera.depth = 11;
        myBulletCamera.depth = 11;

        myTankCameraRotation.eulerAngles = Vector3.zero;
        myBulletCameraRotation.eulerAngles = Vector3.zero;
        playerStatusPanel.SetActive(true);

    }
    public void EnemyStatus()
    {
        ViewReset();

        audio.PlayOneShot(buttonClick);
        enemyTank01Camera.depth = 11;
        enemyTank02Camera.depth = 11;
        enemyBulletCamera.depth = 11;

        enemyTank01CameraRotation.eulerAngles = Vector3.zero;
        enemyTank02CameraRotation.eulerAngles = Vector3.zero;
        enemyBulletCameraRotation.eulerAngles = Vector3.zero;

        enemyStatusPanel.SetActive(true);
    }
    public void ItemStatus()
    {
        ViewReset();

        audio.PlayOneShot(buttonClick);
        heartCamera.depth = 11;
        jewelCamera.depth = 11;
        keyCamera.depth = 11;

        heartCameraRotation.eulerAngles = Vector3.zero;
        jewelCameraRotation.eulerAngles = Vector3.zero;
        keyCameraRotation.eulerAngles = Vector3.zero;

        itemStatusPanel.SetActive(true);
    }
    public void HowToPlayButton()
    {
        ViewReset();

        audio.PlayOneShot(buttonClick);
        HowToPlayPanel.SetActive(true);
    }
    public void BackToIntro()
    {
        audio.PlayOneShot(buttonClick);
        SceneManager.LoadScene("Intro");
    }
    private void ViewReset()
    {
        howToControlCamera.depth = -1;
        keyPanel.SetActive(false);

        myTankCamera.depth = -1;
        myBulletCamera.depth = -1;
        playerStatusPanel.SetActive(false);

        enemyTank01Camera.depth = -1;
        enemyTank02Camera.depth = -1;
        enemyBulletCamera.depth = -1;
        enemyStatusPanel.SetActive(false);

        heartCamera.depth = -1;
        jewelCamera.depth = -1;
        keyCamera.depth = -1;
        itemStatusPanel.SetActive(false);

        HowToPlayPanel.SetActive(false);
    }
}
