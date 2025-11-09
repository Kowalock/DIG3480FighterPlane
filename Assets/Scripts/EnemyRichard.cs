using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRichard : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, -1, 0) * Time.deltaTime * 3f); //moves diagnol right

        if(transform.position.x > 10f)
        {
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z); //wraps around to left side
        }
        else if(transform.position.x < -10f)
        {
            transform.position = new Vector3(10f, transform.position.y, transform.position.z); //wraps around to right side
        }

        if(transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
                                                                          
    }
}