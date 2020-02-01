using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rb;
    public BoxCollider2D collider2D;
    Vector2 movement;
    public float movementX;
    public float movementY;
    //public bool isDirectionReadyToChange = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Hole"))
        {
            if (collision.gameObject.CompareTag("DirectionChangerRight"))
            {
                changeDirectionToTheRight();
            }
            else
            {
                if (collision.gameObject.CompareTag("DirectionChangerLeft"))
                {
                    changeDirectionToTheLeft();
                }
            }
        }
        else
        {

        }
    }

    public void changeDirectionToTheRight()
    {
        if (movementX + movementY == 1) // is up or right
        {
            if (movementX == 1) // is right
            {
                movementX = 0;
                movementY = -1;
            }
            else // is up
            {
                movementX = 1;
                movementY = 0;
            }
        }
        else
        {
            if (movementX == 0) // is down
            {
                movementX = -1;
                movementY = 0;
            }
            else // is left
            {
                movementX = 0;
                movementY = 1;
            }
        }
    }

    public void changeDirectionToTheLeft()
    {
        if (movementX + movementY == 1) // is up or right
        {
            if (movementX == 1) // is right
            {
                movementX = 0;
                movementY = 1;
            }
            else // is up
            {
                movementX = -1;
                movementY = 0;
            }
        }
        else
        {
            if (movementX == 0) // is down
            {
                movementX = 1;
                movementY = 0;
            }
            else // is left
            {
                movementX = 0;
                movementY = -1;
            }
        }
    }

    public void stopCar()
    {
        movementX = 0;
        movementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = movementX;
        movement.y = movementY;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
