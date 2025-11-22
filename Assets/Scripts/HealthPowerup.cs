using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 3f);

    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            PlayerController player = whatDidIHit.GetComponent<PlayerController>();

            if(player.lives < 3)
            {
                player.GetALife();
                gameManager.PlaySound(4);
            }
            else 
            {
                gameManager.AddScore(1);
                gameManager.PlaySound(3);
            }
            Destroy(gameObject);

        }
    }
}
