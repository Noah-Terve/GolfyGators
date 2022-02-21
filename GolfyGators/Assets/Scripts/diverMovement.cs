using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diverMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 movement;
    public GameController handler;
    
    // Start is called before the first frame update
    void Start() {
        // grab the rigidbody from the player object
        rb = GetComponent<Rigidbody2D> ();
        
        if (GameObject.FindWithTag("GameController") != null){
            handler = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        }
    }

    // FixedUpdate is called once per frame before the frame starts
    void FixedUpdate() {
        // Move the object by grabbing the input from the user
        movement.x = Input.GetAxisRaw ("Horizontal");
        movement.y = Input.GetAxisRaw ("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
    // called when we hit another object
    void OnCollisionEnter2D(Collision2D other) {
        // if the player hits a ball
        if (other.gameObject.tag == "golfBall") {
            // get rid of the golf ball and update the score
            Destroy(other.gameObject);
            handler.addScore(1);
        }
        
        // if the player hits a gator
        else if (other.gameObject.tag == "gator") {
            // get rid of the gator? Can remove this later so the gator doesn't
            // die, or we can think of something else
            Destroy(other.gameObject);
            handler.loseScore();
        }
        
    }
    
    
}
