using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpPower;
    public float sensivityHorizontal = 3f;

    private Rigidbody rigidbody;
    private TeleportBehaviour teleportBehaviour;

    private bool isGround;
    private bool isRunning;
    private float fallingSpeed = 18f;
    private float gravityForce;
    private Vector3 movementVector;

    void Start()
    {
        teleportBehaviour = gameObject.GetComponent<TeleportBehaviour>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        PlayerJumping();
        PlayerMove();
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

        if (other.gameObject.tag == "EndTeleport")
        {
            Vector3 newLevel = teleportBehaviour.GetTeleportPosition(other.gameObject.name);
            gameObject.transform.position = newLevel + new Vector3(-6f, -43f, -10f);
        }
    }
}

