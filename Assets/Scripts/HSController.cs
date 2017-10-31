using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HSController : MonoBehaviour
{
    public Text hs_text, panel_text;
    public static int hs_score = 0;
  

    void Awake()
    {
        hs_score = 0;
    }
   
   void OnTriggerEnter2D(Collider2D other)
       {
        if (other.gameObject.tag == "Bomb")
        {
            hs_score += 10;
            hs_text.text = "" + hs_score;
            if (PlayerPrefs.GetInt("HScore") < hs_score)
            {
                panel_text.text = "Новый рекорд: " + hs_score;
                PlayerPrefs.SetInt("HScore", hs_score);
            }
            else if (PlayerPrefs.GetInt("HScore") >= hs_score)
                panel_text.text = "Ваш счет: " + hs_score; ;
        }

    }
      
}