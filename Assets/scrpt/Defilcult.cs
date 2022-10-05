using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defilcult : MonoBehaviour
{

    public void Easy()
   {
     SceneManager.LoadScene("level 1");
   }

   public void Hard()
   {
     SceneManager.LoadScene("level1Hard");
   }

   public void NoHope()
   {
     SceneManager.LoadScene("level1NoHope");
   }

   public void MenuButton()
   {
     SceneManager.LoadScene("MainMenu");
   }
}
