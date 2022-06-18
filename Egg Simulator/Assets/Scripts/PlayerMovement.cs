using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Final variables
    private const float playerSpeed = 7.0f;
    private const float jumpHeight = 1.0f;
    private const float gravityValue = -9.81f;

    // Adjustable variables
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Quaternion initRot;

    public bool movementDisabled = false;

    private void Start() {
        controller = gameObject.AddComponent<CharacterController>();
        initRot = gameObject.transform.rotation;
    }

    void Update() {
        movePlayer();
    }

    private void movePlayer() {
        if (!movementDisabled) {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0) {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero) {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer) {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            gameObject.transform.rotation = initRot;
        }
    }

    public void disableMovement() {
        movementDisabled = true;
    }
    
    public void enableMovement() {
        movementDisabled = false;
    }
}