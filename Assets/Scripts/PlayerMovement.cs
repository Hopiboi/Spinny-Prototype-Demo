using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rg2D;

    [Header("Movement Speed")]
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float sprintSpeed = 12f;
    [SerializeField] private float doubleRotationSpeed = 7f;
    [SerializeField] private float rotationSpeed = 1f;

    [Header("Boolean Condition")]
    private bool canReverseRight = true;
    private bool canReverseLeft = false;


    private void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SpinnyMovement();
    }


    public void SpinnyMovement()
    {
        MovementConditions();

        if (canReverseRight == true)
        {
            RotationControls();

            if (Input.GetKey(KeyCode.Q))
            {
                canReverseRight = false;
                canReverseLeft = true;
            }
        }


        else if (canReverseLeft == true)
        {
            ReverseRotationControls();

            if (Input.GetKey(KeyCode.E))
            {
                canReverseRight = true;
                canReverseLeft = false;
            }
        }
    }

    public void MovementConditions()
    {
        MovementKeys();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            SprintMovementKeys();
        }

    }

    public void MovementKeys()
    {

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * this.movementSpeed * Time.deltaTime;
        }
    }

    public void SprintMovementKeys()
    {

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.sprintSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.sprintSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * this.sprintSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * this.sprintSpeed * Time.deltaTime;
        }
    }

    public void RotationControls()
    {
        //Rotation Speed
        this.transform.Rotate(new Vector3(0, 0, rotationSpeed));

        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Rotate(new Vector3(0, 0, doubleRotationSpeed));
        }
    }

    public void ReverseRotationControls()
    {
        //Rotation Speed
        this.transform.Rotate(new Vector3(0, 0, -rotationSpeed));

        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Rotate(new Vector3(0, 0, -doubleRotationSpeed));
        }
    }
}
