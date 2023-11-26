using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GW_ButtonManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip buttonSound;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void ToIntroButton()
    {
        audio.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Intro");
    }
    public void ExitGame()
    {
        audio.PlayOneShot(buttonSound);
        Application.Quit();
    }
}
