using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour{

    // [Headers("Ball Config")]
    public float initialSpeed = 10f;
    public float speedIncrease = 0.2f;
    public Text playerText;
    public Text OpponentText;
    

    private int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall(){
        rb.velocity = new Vector2(-1, 0)*(initialSpeed + speedIncrease * hitCounter);
    }

    private void RestartBall(){
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce(Transform obj){
        hitCounter++;
        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = obj.position;

        float xDirection;
        float yDirection;

        if(transform.position.x>0){
            xDirection = -1;
        }else{
            xDirection = 1;
        }

        yDirection = (ballPosition.y-playerPosition.y)/obj.GetComponent<Collider2D>().bounds.size.y;
        if (yDirection == 0){
            yDirection = 0.25f;
        }

        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed+(speedIncrease*hitCounter));
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "paddleA" || other.gameObject.name == "paddleB"){
            PlayerBounce(other.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(transform.position.x>0){
            RestartBall();
            OpponentText.text = (int.Parse(OpponentText.text) + 1).ToString();
        }else if(transform.position.x<0){
            RestartBall();
            playerText.text = (int.Parse(playerText.text)+1).ToString();
        }
    }

}
