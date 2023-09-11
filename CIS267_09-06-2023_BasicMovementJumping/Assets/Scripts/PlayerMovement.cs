using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    private float inputHorizontal;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        //I can only get this component using the following line of code
        //because the rigidbody2d is attached to the player and this script
        //is also attached to the player.
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");

        //Basic movement not ideal
        //Moves object but ignores collisions
        //transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //Value returned will be 0, 1, or -1 depending on the button pressed
        //no button        :  0
        //right arrow or d :  1
        //left arrow or a  : -1
        //"Horizontal" is defined in the input section of project settings
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
    }
}
