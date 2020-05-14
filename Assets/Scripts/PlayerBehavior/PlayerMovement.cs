using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpPower;
    public float sensivityHorizontal = 3f;

    private Rigidbody rigidbody;

    private bool isGround;
    private float fallingSpeed = 18f;
    private float gravityForce;
    private Vector3 movementVector;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        PlayerGravitation();
        PlayerMove();
    }

    private void PlayerGravitation()
    {
        

        PlayerJumping();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = 1 * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -1 * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movementVector.z = 1 * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVector.z = -1 * playerSpeed * Time.deltaTime;
        }

        transform.Translate(movementVector);
        movementVector = Vector3.zero;
    }

    private void PlayerJumping() 
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rigidbody.AddForce(Vector3.up * jumpPower);
            isGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}

