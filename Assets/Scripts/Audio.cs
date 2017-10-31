using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public Sprite volume_on, volume_off;
   

    private void Awake()
    {
        if (gameObject.name == "Volume")
        {
            if (PlayerPrefs.GetString("Volume") == "off")
            {
                GetComponent<Image>().sprite = volume_off;
                AudioListener.volume = 0f;
               // Camera.main.GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Volume":
                if (PlayerPrefs.GetString("Volume") == "off")
                {
                    GetComponent<Image>().sprite = volume_on;
                    PlayerPrefs.SetString("Volume", "on");
                    AudioListener.volume = 1f;
                    //Camera.main.GetComponent<AudioListener>().enabled = true;
                }
                else
                {
                    GetComponent<Image>().sprite = volume_off;
                    PlayerPrefs.SetString("Volume", "off");
                    AudioListener.volume = 0f;
                    // Camera.main.GetComponent<AudioListener>().enabled = false;
                }
                break;
        }
    }
}
