using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public Vector2 velocity;
    public float speed;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            // myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2 (-speed, myRigibody.velocity.y);
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(speed, myRigibody.velocity.y);
        }
    }
}
