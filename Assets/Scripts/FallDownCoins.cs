using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallDownCoins : MonoBehaviour
{
    private float fallSpeed = 4f;

    void Update()
    {
        if (transform.position.y < -6f)
            Destroy(gameObject);

        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            if (Player.lose) {
                trig.GetComponent<Collider2D>().enabled = false;
            }
            Destroy(gameObject);
        }
    }
}