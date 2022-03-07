using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diverMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float speed = 5f;
    public Vector2 movement;
    public GameController handler;
    private bool faceRight = false;
    public AudioSource sfxHurt;
    public AudioSource sfxGrabBall;
    
    // Start is called before the first frame update
    void Start() {
        // grab the rigidbody from the player object
        rb = GetComponent<Rigidbody2D> ();
        
        // grab the animator
        anim = gameObject.GetComponentInChildren<Animator>();
        
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
        
        // Updating the movement so it can be animated
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)){
              anim.SetBool ("Swimming", true);
        } else {anim.SetBool ("Swimming", false);}
        
        if ((movement.x <0 && !faceRight) || (movement.x >0 && faceRight)){
                  playerTurn();
        }
    }
    
    private void playerTurn(){
        // NOTE: Switch player facing label
       faceRight = !faceRight;

       // NOTE: Multiply player's x local scale by -1.
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
     }
    
    // called when we hit another object
    void OnCollisionEnter2D(Collision2D other) {
        // if the player hits a ball
        if (other.gameObject.tag == "golfBall") {
            // get rid of the golf ball and update the score
            Destroy(other.gameObject);
            handler.addScore(1);
            sfxGrabBall.Play();
        }
        
        // if the player hits a gator
        else if (other.gameObject.tag == "gator") {
            // get rid of the gator? Can remove this later so the gator doesn't
            // die, or we can think of something else
            Destroy(other.gameObject);
            handler.loseScore();
            sfxHurt.Play();
        }
        
        if (other.gameObject.tag == "gold") {
            // get rid of the golf ball and update the score
            Destroy(other.gameObject);
            handler.addScore(2);
            sfxGrabBall.Play();
        }
    }
    
    
}
