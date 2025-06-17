using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public PlayerPawn playerPawn; // Reference to the pawn
    public Transform tf;          // Transform reference
    private Rigidbody rb;         // Rigidbody reference

    // Ship movement variables
    public float shipSpeed = 5f;
    public float shipTurnSpeed = 100f; // Use a higher value for visible rotation
    public float shipTurboSpeed = 10f;

    // Customizable input keys
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode turboKey = KeyCode.LeftShift;
    public KeyCode Shoot = KeyCode.Space;

    // Additional keys for pitch and roll (if needed)
    public KeyCode pitchUpKey = KeyCode.UpArrow;
    public KeyCode pitchDownKey = KeyCode.DownArrow;
    public KeyCode rollLeftKey = KeyCode.LeftArrow;
    public KeyCode rollRightKey = KeyCode.RightArrow;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (tf == null)
            tf = transform;
    }

    void Update()
    {
        if (playerPawn != null)
        {
            playerPawn.PrintHello();
        }

        HandleInput();
    }

    void HandleInput()
    {
        PlayerMovement();

        if (Input.GetKeyDown(Shoot))
        {
            playerPawn.Shoot();
        }
    }

    void PlayerMovement()
    {
        float yawInput = 0f;
        float pitchInput = 0f;
        float rollInput = 0f;
        float moveInput = 0f;

        // Forward/backward movement using W/S (or keys defined in inspector)
        if (Input.GetKey(forwardKey)) moveInput += 1f;
        if (Input.GetKey(backwardKey)) moveInput -= 1f;

        // Yaw using Left/Right Arrows
        if (Input.GetKey(KeyCode.LeftArrow)) yawInput -= 1f;
        if (Input.GetKey(KeyCode.RightArrow)) yawInput += 1f;

        // Pitch using Up/Down Arrows
        if (Input.GetKey(KeyCode.UpArrow)) pitchInput -= 1f;   // Nose up
        if (Input.GetKey(KeyCode.DownArrow)) pitchInput += 1f; // Nose down

        // Roll using Q and E
        if (Input.GetKey(KeyCode.E)) rollInput -= 1f;
        if (Input.GetKey(KeyCode.Q)) rollInput += 1f;

        float speed = Input.GetKey(turboKey) ? shipTurboSpeed : shipSpeed;

        // Move forward/backward
        Vector3 moveAmount = Vector3.forward * moveInput * speed * Time.deltaTime;
        tf.Translate(moveAmount, Space.Self);

        // Apply yaw, pitch, and roll rotation
        Vector3 rotationAmount = new Vector3(
            pitchInput * shipTurnSpeed,
            yawInput * shipTurnSpeed,
            rollInput * shipTurnSpeed
        ) * Time.deltaTime;

        tf.Rotate(rotationAmount, Space.Self);
    }
}