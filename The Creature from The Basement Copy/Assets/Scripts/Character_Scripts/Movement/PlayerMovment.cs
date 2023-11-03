using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movment")]

    [SerializeField] float moveSpeed;

    public Transform orientation;

    [SerializeField] float drag;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        rb.drag = drag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVal =  new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVal.magnitude > moveSpeed)
        {
            Vector3 limitedVal = flatVal.normalized * moveSpeed;
            rb.velocity = new Vector3 (limitedVal.x, rb.velocity.y, limitedVal.z);
        }
    }
}