using UnityEditor.Animations;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public GameObject explosionPrefab;

    private GameManager gameManager;
    private int direction;

    private float horizontalScreenLimit = 12f;
    private float verticalScreenLimit = 4f;
    public float horizontalBuffer = 2f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Move side to side
        transform.Translate(new Vector3(1, 0, 0) * direction * Time.deltaTime * 3f);

        //Change direction and go one down once it reaches the end
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            direction *= -1;

            transform.Translate(new Vector3(0, -1, 0) * 2f);
        }

        //Destroy when it reaches the bottom
        if (transform.position.y < -verticalScreenLimit)
        {
            Destroy(this.gameObject);
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