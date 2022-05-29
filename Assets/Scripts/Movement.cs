using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;
    public Transform cameraTransform;

    private CharacterController characterController;
    private Animator animator;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        originalStepOffset = characterController.stepOffset;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection = Quaternion.AngleAxis(
            cameraTransform.rotation.eulerAngles.y,
            Vector3.up
        ) * movementDirection;
        movementDirection.Normalize();

        animator.SetFloat("Velocity", magnitude);

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded) lastGroundedTime = Time.time;

        if (Input.GetButton("Jump")) jumpButtonPressedTime = Time.time;
    
        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod) {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod) {
                ySpeed = jumpSpeed;
                lastGroundedTime = null;
                jumpButtonPressedTime = null;
            }
        }
        else {
            characterController.stepOffset = 0f;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                toRotation, 
                rotationSpeed * Time.deltaTime
            );
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) {
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
