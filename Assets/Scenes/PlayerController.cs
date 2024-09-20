using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayerA = false;   // Determines if this paddle is Player A
    public GameObject circle;        // The ball in the game
    public bool isAi = true;         // Determines if this paddle is controlled by AI
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerA)
        {
            PaddleControllerA(); // Player A controls (W/S)
        }
        else if (isAi)
        {
            PaddleControllerAI(); // AI controls the second paddle
        }
        else
        {
            SecondPlayer(); // Player B controls (arrow keys)
        }
    }

    // Player A uses W and S keys to move
    private void PaddleControllerA()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerMovement = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerMovement = new Vector2(0, -1);
        }
        else
        {
            playerMovement = new Vector2(0, 0);
        }
    }

    // AI movement for Player B (follows the ball)
    private void PaddleControllerAI()
    {
        if (circle.transform.position.y > transform.position.y + 0.5f)
        {
            playerMovement = new Vector2(0, 1);
        }
        else if (circle.transform.position.y < transform.position.y - 0.5f)
        {
            playerMovement = new Vector2(0, -1);
        }
        else
        {
            playerMovement = new Vector2(0, 0);
        }
    }

    // Player B uses the up and down arrow keys to move
    private void SecondPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerMovement = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerMovement = new Vector2(0, -1);
        }
        else
        {
            playerMovement = new Vector2(0, 0);
        }
    }

    // Apply movement in FixedUpdate for physics consistency
    private void FixedUpdate()
    {
        rb.velocity = playerMovement * speed;
    }
}
