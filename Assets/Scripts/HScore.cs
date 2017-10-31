using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HScore : MonoBehaviour {

    [SerializeField] private Text coins_sc;

    void Update()
    {
        coins_sc = GetComponent<Text>();
        coins_sc.text = PlayerPrefs.GetInt("HScore").ToString();
    }
}
