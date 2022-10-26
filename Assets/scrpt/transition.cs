using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    public void levelEasy()
   {
     SceneManager.LoadScene("Level2");
   }

   public void levelHard()
   {
     SceneManager.LoadScene("Level2Hard");
   }

   public void levelNoHope()
   {
     SceneManager.LoadScene("Level2NoHope");
   }

   public void levelEasycredit()
   {
     SceneManager.LoadScene("CreditEasy");
   }

   public void levelHardcredit()
   {
     SceneManager.LoadScene("Credithard");
   }

   public void levelNoHopecredit()
   {
     SceneManager.LoadScene("CreditNoHope");
   }

}
