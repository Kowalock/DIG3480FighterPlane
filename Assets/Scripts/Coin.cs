using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 2f;
    private float direction;

    void Start()
    {
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
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1);

            Destroy(gameObject);
        }
    }

}
