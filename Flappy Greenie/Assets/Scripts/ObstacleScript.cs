using System.Collections;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    float dragonXposition;
    bool isScoreAdded;

   GameManagerScript gameManager;
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(-2.5f, 0);
        dragonXposition = GameObject.Find("Dragon").transform.position.x;
        isScoreAdded = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        if (transform.position.x <= dragonXposition)
        {
            if (!isScoreAdded)
            {
                Addscore();
                isScoreAdded = true;
            }
        }
        if (transform.position.x <= -9f)
        {
            Destroy(gameObject);
        }
    }
    void Addscore()
    {
        gameManager.GmAddScore();

    }
}
