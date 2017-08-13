using System.Collections;
using UnityEngine;

public class DragonScript : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private float jumpforce;
    public bool isAlive;

    void Start()
    {
        isAlive = true;

        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();

        jumpforce = 10f;
        myRigidBody.gravityScale = 5f;


    }
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetMouseButton(0))
            {
                Flap();
            }
            CheckIfDragonVisibleOnScreen();
        }
    }

    void Flap()
    {
        myRigidBody.velocity = new Vector2(0, jumpforce);

        myAnimator.SetTrigger("Flap");
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacles")
        {
            isAlive = false;
            Time.timeScale = 0f;
        }
    }

    void CheckIfDragonVisibleOnScreen()
    {
        if (Mathf.Abs(gameObject.transform.position.y) > 5.46f)
        {
            isAlive = false;
            Time.timeScale = 0f;
        }
    }
}