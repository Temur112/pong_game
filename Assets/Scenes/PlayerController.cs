using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayerA = false;
    public GameObject circle;
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
        if (isPlayerA){
            PaddleControllerA();
        }else{
            PaddleControllerB();
        }   
    }
    private void PaddleControllerB(){
        if(circle.transform.position.y > transform.position.y + 0.5f){
            playerMovement = new Vector2(0,1);
        }else if(circle.transform.position.y < transform.position.y - 0.5f){
            playerMovement = new Vector2(0, -1);
        }else{
            playerMovement = new Vector2(0, 0);
        }
    }

    private void PaddleControllerA(){
        playerMovement = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate(){
        rb.velocity = playerMovement * speed;
    }
}
