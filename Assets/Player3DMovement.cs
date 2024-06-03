using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DMovement : MonoBehaviour
{
    public float MoveSpeed = 10;
    public float JumpForce = 5;
    public Rigidbody rb;
    public float gravity = 1;
    public float maxJumpHeight = 1.0f;
    public float maxJumpTime = 0.5f;
    public float initialJumpVelocity;
    private bool IsGrounded = true;

    void Start()
    {
        SetupJumpVariables();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * MoveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGrounded = true;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * initialJumpVelocity, ForceMode.Impulse);
        IsGrounded = false;
    }

    void SetupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    
}
