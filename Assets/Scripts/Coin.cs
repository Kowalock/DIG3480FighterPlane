using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 2f;
    private float direction;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = transform.position.x < 0 ? 1f : -1f; // Determine direction based on initial position
        Destroy(gameObject, 2f); //coin destroys after 2 seconds
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.AddScore(1);
            gameManager.PlaySound(3);
            Destroy(gameObject, 0.1f);
        }
    }

}
