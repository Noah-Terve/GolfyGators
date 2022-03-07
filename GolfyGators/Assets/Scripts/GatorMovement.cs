using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;
    private float horMin;
    public AudioSource getBall;
    

      // Auto-load the RigidBody component into the variable:
    void Start(){
        rb = GetComponent<Rigidbody2D> ();
        //gets the left edge of the screen
        horMin = -Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update(){
        movement.x = -1;
        // moves gator left
        rb.MovePosition(rb.position + movement * moveSpeed
                                            * Time.fixedDeltaTime);
        //destroys gator after it goes offscreen
        if (transform.position.x < horMin) {
            Destroy(gameObject);
       }
    }
    void OnCollisionEnter2D(Collision2D other) {
        // if the gator hits a ball
        if (other.gameObject.tag == "golfBall") {
            // get rid of the golf ball
            Destroy(other.gameObject);
            getBall.Stop();
            getBall.Play();
        }
    }
}
