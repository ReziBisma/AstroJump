using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Sprite[] spriteMute;// 0 = on 1 = off
    public Button buttonMute;
    private int _score = 0;
    public Defilcult defil;
    public void Defilcult()
    {
        defil.Setup(_score);
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        Defilcult();
    }

    public void Us()
    {
        SceneManager.LoadScene("AbouthUs");
    }

    public void ButtonMute()
    {
        SoundManager.Instance.MuteSound();

        if (SoundManager.Instance.music.mute == true)
        {
            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {
            buttonMute.image.sprite = spriteMute[0];
        }

    }
}
