using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Defilcult : MonoBehaviour
{
  public Text pointsText;
    public SoundManager sound;
    

   public void Setup(int score)
   {
    gameObject.SetActive(true);
    pointsText.text = score.ToString() + " POINTS";    
   }

    public void Easy()
   {
     SceneManager.LoadScene("level 1");
        sound.music.Pause();
   }

   public void Hard()
   {
     SceneManager.LoadScene("level1Hard");
        sound.music.Pause();
    }

   public void NoHope()
   {
     SceneManager.LoadScene("level1NoHope");
        sound.music.Pause();
    }

   public void MenuButton()
   {
     SceneManager.LoadScene("MainMenu");
   }
}
