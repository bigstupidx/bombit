using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.UI;






public class RewardAds : MonoBehaviour {

    private string gameId = "1594141";
    public Text sorryText, cost_text;
    public GameObject ads_button;
    Button m_Button;

    public string placementId = "rewardedVideo";

    void Start () {

        m_Button = GetComponent<Button>();
        if (m_Button) m_Button.onClick.AddListener(ShowAd);

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true); /// Проверяй!
        }
        
    }
	
	
	void Update () {
      //  if (m_Button) m_Button.interactable = Advertisement.IsReady(placementId);
        if (FallDown._score2 >= 50)
        {
            cost_text.text = "+50";
        }
        else if (FallDown._score2 >= 30)
        {
            cost_text.text = "+35";
        }
        else if (FallDown._score2 >= 20)
        {
            cost_text.text = "+15";
        }
        else if (FallDown._score2 >= 10)
        {
            cost_text.text = "+5";
        }
        else if (FallDown._score2 < 10)
        {
            cost_text.text = "+3";
        }
    }

    void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result)
    {

        if (result == ShowResult.Finished)
        {
            if (FallDown._score2 >= 50)
            {
                
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
            }
            else if (FallDown._score2 >= 30)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 35);
            }
            else if (FallDown._score2 >= 20)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 15);
            }
            else if (FallDown._score2 >= 10)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 5);
            }
            else if (FallDown._score2 < 10)
            {
                
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 3);
            }
            ads_button.SetActive(false);
            Debug.Log("Video completed - Offer a reward to the player");
            sorryText.text = "Биткоины зачислены!";
            
        }
        else if (result == ShowResult.Skipped)
        {
            ads_button.SetActive(false);
            sorryText.text = "Вы должны посмотреть рекламу полностью для получения биткоинов";
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            ads_button.SetActive(false);
            sorryText.text = "Упс! Видео не загрузилось. Попробуйте немного позже!";
            Debug.LogError("Video failed to show");
        }
    }

}
