using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRichard : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManager gameManager;

    private float horizontalScreenLimit = 11f;
    private float verticalScreenLimit = 4f;
    public float horizontalBuffer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, -1, 0) * Time.deltaTime * 3f); //moves diagnol right

        if (transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, transform.position.z); //wraps around to left side
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, transform.position.z); //wraps around to right side
        }

        if (transform.position.y < -verticalScreenLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            Destroy(this.gameObject);
        }
    }
}

 