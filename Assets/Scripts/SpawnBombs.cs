using System.Collections;
using UnityEngine;

public class SpawnBombs : MonoBehaviour {

    public GameObject bomb,coins;
    public float spawnspeed = 1f;
    public static float spawnCoinspeed = 5f;

    void Start() {
        StartCoroutine(SpawnBomb ());
        StartCoroutine(SpawnCoin());  
    }

    IEnumerator SpawnBomb() {
        while (!Player.lose)
        {
            Instantiate(bomb, new Vector2(Random.Range(-2f, 2f), 6.6f), Quaternion.identity);        
            yield return new WaitForSeconds(spawnspeed);
        }
    }

    IEnumerator SpawnCoin() {
        while (!Player.lose)
        {    
            Instantiate(coins, new Vector2(Random.Range(-2f, 2f), 13.6f), Quaternion.identity);
            yield return new WaitForSeconds(spawnCoinspeed);
        }
    }
}
