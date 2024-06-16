using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rg2D;

    [Header("Movement Speed")]
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float doubleRotationSpeed = 7f;
    [SerializeField] private float rotationSpeed = 1f;

    private void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //fixed update if its not possible
        this.transform.Rotate(new Vector3(0, 0, rotationSpeed));

        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(new Vector3(0, 0, doubleRotationSpeed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left  * this.movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * this.movementSpeed * Time.deltaTime;
        }
    }


}
