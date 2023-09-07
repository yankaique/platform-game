using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public float speed;
    public float forceJump = 2;
    public Vector2 friction = new Vector2(.1f, 0);

    // public Vector2 velocity;
    void Update()
    {
        HandleMovement();
        HandleJump();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(-speed, myRigibody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(speed, myRigibody.velocity.y);
        }

        if (myRigibody.velocity.x > 0)
        {
            myRigibody.velocity -= friction;
        }
        else if (myRigibody.velocity.x < 0)
        {
            myRigibody.velocity += friction;
        }
    }

        private void HandleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
                myRigibody.velocity = Vector2.up * forceJump;
            }
        }
}
