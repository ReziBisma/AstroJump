using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
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
}
