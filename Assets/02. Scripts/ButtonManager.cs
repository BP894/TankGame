using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioClip buttonClick;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void StartGameButton()
    {
        audio.PlayOneShot(buttonClick);
        SceneManager.LoadScene("Main");
    }
    public void HowToPlayButton()
    {
        audio.PlayOneShot(buttonClick);
        SceneManager.LoadScene("HowToPlay");    
    }
    public void ExitGame()
    {
        audio.PlayOneShot(buttonClick);
        Application.Quit();
    }
}
