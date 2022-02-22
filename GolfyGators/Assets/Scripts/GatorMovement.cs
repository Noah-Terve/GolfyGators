using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 movement;
    //public GameHandler gameHandlerObj;
    //public GameObject hitVFX;

      // Auto-load the RigidBody component into the variable:
    void Start(){
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update(){
        movement.x = -1;
        rb.MovePosition(rb.position + movement * 2 * moveSpeed * Time.fixedDeltaTime);
            if (transform.position.x < -10){
                Destroy(gameObject);
            }
    }
}
