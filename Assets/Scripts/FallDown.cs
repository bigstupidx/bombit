using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FallDown : MonoBehaviour {

    [SerializeField] private float fallSpeed = 3f;
    public GameObject bomb, boom;
    private int _score2, _score3;
    SpawnBombs spawnBombs;
    Rigidbody2D rigidbody2D;
    
    void Awake()
    { 
       boom.SetActive(false);
       
    }
   
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            trig.GetComponent<Collider2D>().enabled = false;
            transform.position = new Vector3(gameObject.transform.position.x, -1.5f, 0);
            Destroy(bomb);
            boom.SetActive(true);
            //фризит бомбу
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }


    void Update () {
        
        _score2 = Player._score;
        _score3 = HSController.hs_score;

        if (transform.position.y < -6f) {
            Destroy(gameObject);
        }


        if (_score2 > 5 && _score2 <= 10)
        {
            //   fallSpeed = 5f;
            spawnBombs = Camera.main.GetComponent("SpawnBombs") as SpawnBombs;
            spawnBombs.spawnspeed = 0.8f;
            _score3 = HSController.hs_score += 1;
            
        }

        if (_score2 > 10 && _score2 <= 18)
        {
            //   fallSpeed = 5f;
            spawnBombs = Camera.main.GetComponent("SpawnBombs") as SpawnBombs;
            spawnBombs.spawnspeed = 0.7f;
            _score3 = HSController.hs_score += 2;

        }

        if (_score2 > 18 && _score2 <= 30)
        {
            //   fallSpeed = 5f;

            spawnBombs = Camera.main.GetComponent("SpawnBombs") as SpawnBombs;
            spawnBombs.spawnspeed = 0.6f;
            _score3 = HSController.hs_score += 3;
            SpawnBombs.spawnCoinspeed = 3f;
        }

        if (_score2 > 30 && _score2 <= 50)
        {
            //   fallSpeed = 9f;
            spawnBombs = Camera.main.GetComponent("SpawnBombs") as SpawnBombs;
            spawnBombs.spawnspeed = 0.4f;
            _score3 = HSController.hs_score += 4;
            SpawnBombs.spawnCoinspeed = 2.5f;
        }
        if (_score2 > 50)
        {
            //   fallSpeed = 9f;
            spawnBombs = Camera.main.GetComponent("SpawnBombs") as SpawnBombs;
            spawnBombs.spawnspeed = 0.3f;
            _score3 = HSController.hs_score += 5;
            SpawnBombs.spawnCoinspeed = 2f;
        }
        //   transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }
   
}
