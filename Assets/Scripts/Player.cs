using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    public static bool lose = false;
    public GameObject player,restart,exit,panel_lose;
    public Text coins_txt;
    public static int _score = 0;
    public GameObject[] blogers;
    
    

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
        blogers[PlayerPrefs.GetInt("b")].SetActive(true);
        player = blogers[PlayerPrefs.GetInt("b")];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bomb")
        { 

            transform.position = new Vector3(gameObject.transform.position.x, -4.4f,0);
            transform.Rotate(Vector3.forward * 90); 
            lose = true;
            panel_lose.SetActive(true);
            
        }

        if (other.gameObject.tag == "Coin") { 
            _score++;
            GetComponent<AudioSource>().Play();
            coins_txt.text = "" + _score;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
        }
       
    }
}
