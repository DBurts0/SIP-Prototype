using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public KeyCode rotateLeft;
    public KeyCode rotateRight;
    public KeyCode forwards;
    public KeyCode backwards;
    private CharacterData data;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<CharacterData>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is pressing the forwards key
        if (Input.GetKey(forwards))
        {
            Forwards();
        }
        // Check if the player is pressing the backwards key
        if (Input.GetKey(backwards))
        {
            Backwards();
        }
        // Check if the player is pressing the left key
        if (Input.GetKey(rotateLeft))
        {
            RotateLeft();
        }
        // Check if the player is pressing the right key
        if (Input.GetKey(rotateRight))
        {
            RotateRight();
        }
    }

    void Forwards()
    {
        // Move the character forwards by creating a new Vector 3 position infront of the player
        Vector3 direction;
        direction = transform.forward;
        direction *= data.moveSpeed;
        controller.SimpleMove(direction);
    }

    void Backwards()
    {
        // Move the character backwards by creating a new Vector 3 position behind the player
        Vector3 direction;
        direction = transform.forward;
        direction *= (-1 * data.moveSpeed);
        controller.SimpleMove(direction);
    }

    void RotateRight()
    {
        // Rotate the character to the right based on the set turn speed
        Vector3 rotationVector;
        rotationVector = new Vector3(0, 1, 0);
        rotationVector *= data.turnSpeed * Time.deltaTime;
        transform.Rotate(rotationVector, Space.Self);
    }

    void RotateLeft()
    {
        // Rotate the character to the left based on the set turn speed
        Vector3 rotationVector;
        rotationVector = new Vector3(0, -1, 0);
        rotationVector *= data.turnSpeed * Time.deltaTime;
        transform.Rotate(rotationVector, Space.Self);
    }

}
