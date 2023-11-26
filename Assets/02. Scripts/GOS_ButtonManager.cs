using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOS_ButtonManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip buttonSound;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void ToTitleButton()
    {
        audio.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Intro");
    }
    public void ToRestartButton()
    {
        audio.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Main");
    }
    public void ExitGame()
    {
        audio.PlayOneShot(buttonSound);
        Application.Quit();
    }
}
