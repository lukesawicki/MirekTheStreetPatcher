using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rb;
    Vector2 movement;
    public GameObject hole;
    public bool isOnWhole = false;
    public bool pressing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I hit something");
        isOnWhole = true;
        hole = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("I'm not hitting");
        isOnWhole = false;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        pressing = Input.GetKeyDown(KeyCode.Space);

        if (pressing && isOnWhole)
        {
            Destroy(hole);
            //hole.GetComponent<Renderer>().enabled = false;
            //hole.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
