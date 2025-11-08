using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    private GameManager gameManager;

    private int direction;

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
        if (transform.position.x > 10f || transform.position.x < -10f)
        {
            direction *= -1;

            transform.Translate(new Vector3(0, -1, 0) * 2f);
        }

        //Destroy when it reaches the bottom
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}