// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float speed = 10f;
//     public bool isPlayerA = false; // Set this from the inspector to distinguish between paddles
//     public GameObject circle;
//     private Rigidbody2D rb;
//     private Vector2 playerMovement;

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (isPlayerA)
//         {
//             PaddleControllerA();  // Control for Player A
//         }
//         else
//         {
//             PaddleControllerB();  // Control for Player B
//         }
//         rb.velocity = playerMovement * speed;
//     }

//     private void MPaddleControllerB()
//     {
//         // Use 'W' and 'S' for Player A
//         if (Input.GetKey(KeyCode.W))
//         {
//             playerMovement = new Vector2(0, 1);
//         }
//         else if (Input.GetKey(KeyCode.S))
//         {
//             playerMovement = new Vector2(0, -1);
//         }
//         else
//         {
//             playerMovement = new Vector2(0, 0);
//         }
//     }

//     private void MPaddleControllerA()
//     {
//         // Use arrow keys for Player B
//         if (Input.GetKey(KeyCode.UpArrow))
//         {
//             playerMovement = new Vector2(0, 1);
//         }
//         else if (Input.GetKey(KeyCode.DownArrow))
//         {
//             playerMovement = new Vector2(0, -1);
//         }
//         else
//         {
//             playerMovement = new Vector2(0, 0);
//         }
//         rb.velocity = playerMovement * speed;
//     }

//     // Apply movement in FixedUpdate for physics consistency
//     // private void FixedUpdate()
//     // {
        
//     // }
// }
