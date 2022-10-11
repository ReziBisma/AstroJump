using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverLv2 : MonoBehaviour
{
    public Text pointsText;

   public void Setup(int score)
   {
    gameObject.SetActive(true);
    pointsText.text = score.ToString() + " POINTS"; 
   }
   public void RestartButton()
   {
     SceneManager.LoadScene("Level2");
     Time.timeScale = 1;
   }
   public void RestartButtonhard()
   {
     SceneManager.LoadScene("Level2Hard");
     Time.timeScale = 1;
   }

   public void RestartButtonNoHope()
   {
     SceneManager.LoadScene("Level2Nohope");
     Time.timeScale = 1;
   }

   public void MenuButton()
   {
     SceneManager.LoadScene("MainMenu");
     Time.timeScale = 1;
   }
}
