using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour {

    public static bool lose = false;
    public GameObject player,restart,exit,panel_lose, rewarded_btn;
    public Text coins_txt;
    public static int _score = 0, ads = 0, rewarded_ads = 0;
    public GameObject[] blogers;
    public string placementId = "rewardedVideo";
    private string gameId = "1594141";
    public Button Button_pause;

    void Awake()
    {
      //  PlayerPrefs.DeleteKey("Coins");
        lose = false;
        _score = 0;
        if (PlayerPrefs.GetString("Volume") == "off")
            AudioListener.volume = 0f; 
    }

    void Start()
    {
        if (Advertisement.isSupported)
            Advertisement.Initialize(gameId, false); // ПРОВЕРЬ НА FALSE ИЛИ TRUE
        blogers[PlayerPrefs.GetInt("b")].SetActive(true);
        player = blogers[PlayerPrefs.GetInt("b")];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        { 

            transform.position = new Vector3(gameObject.transform.position.x, -4.7f,0);
            transform.Rotate(Vector3.forward * 90);
            Lose();
            
        }

        if (other.gameObject.tag == "Coin") { 
            _score++;
            GetComponent<AudioSource>().Play();
            coins_txt.text = "" + _score;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
        }
       
    }

    void Lose() {
        rewarded_ads++;
        ads++;
        lose = true;
        panel_lose.SetActive(true);
        Button_pause.interactable = false;
        if (Advertisement.IsReady() && ads %2 ==0 ) {
            Advertisement.Show();
        }
        if (rewarded_ads % 3 == 0)
            rewarded_btn.SetActive(true);          
    }

    

}
