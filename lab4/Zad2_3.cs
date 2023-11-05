using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad2_3 : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool playerIsTouchingGround;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 4.0f;
    private float gravityValue = -9.81f;
    private float horizontal;
    private float vertical;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        setAxes();
        onMove(moveTo());
        onJump();
        onJumpEnd();
    }

    private void setAxes() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private Vector3 moveTo() {
        return new Vector3(horizontal, 0, vertical);
    }

    private void onJumpEnd() {
        playerIsTouchingGround = controller.isGrounded;
        if (playerIsTouchingGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private void onJump() {
        if (Input.GetButtonDown("Jump") && playerIsTouchingGround) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    private void onMove(Vector3 vector3) {
        controller.Move(vector3 * Time.deltaTime * playerSpeed);
    }
}
