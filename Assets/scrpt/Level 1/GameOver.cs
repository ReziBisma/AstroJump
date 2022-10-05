using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;

   public void Setup(int score)
   {
    gameObject.SetActive(true);
    pointsText.text = score.ToString() + " POINTS"; 
   }
   public void RestartButton()
   {
     SceneManager.LoadScene("level 1");
     Time.timeScale = 1;
   }

   public void RestartButtonHard()
   {
     SceneManager.LoadScene("level1Hard");
     Time.timeScale = 1;
   }

   public void RestartButtonNoHope()
   {
     SceneManager.LoadScene("level1NoHope");
     Time.timeScale = 1;
   }

   public void MenuButton()
   {
     SceneManager.LoadScene("MainMenu");
     Time.timeScale = 1;
   }
}
