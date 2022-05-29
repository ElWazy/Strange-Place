using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpHeight;
    public float gravityMultiplier;
    public float jumpButtonGracePeriod;
    public Transform cameraTransform;

    private CharacterController characterController;
    private Animator animator;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private bool isRecovering;

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

        float gravity = Physics.gravity.y * gravityMultiplier;
        if (isJumping && ySpeed > 0 && !Input.GetButton("Jump")) gravity *= 2;
        ySpeed += gravity * Time.deltaTime;

        if (characterController.isGrounded) lastGroundedTime = Time.time;

        if (Input.GetButton("Jump")) jumpButtonPressedTime = Time.time;
    
        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod) {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);


            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod) {
                ySpeed = Mathf.Sqrt(jumpHeight * -3 * gravity);
                animator.SetBool("IsJumping", true);
                isJumping = true;
                lastGroundedTime = null;
                jumpButtonPressedTime = null;
            }
        }
        else {
            characterController.stepOffset = 0f;
            animator.SetBool("IsGrounded", false);
            isGrounded = false;

            if ((isJumping && ySpeed < 0) || ySpeed < -2) animator.SetBool("IsFalling", true);
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity = AdjustVelocityToSlope(velocity);
        velocity.y += ySpeed;

        if (!animator.GetBool("IsRecovering")) characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero) {
            animator.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                toRotation, 
                rotationSpeed * Time.deltaTime
            );
        } else {
            animator.SetBool("IsMoving", false);
        }
    }

    private Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 0.4f)) {
            Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Vector3 adjustedVelocity = slopeRotation * velocity;

            if (adjustedVelocity.y < 0) return adjustedVelocity;
        }

        return velocity;
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
