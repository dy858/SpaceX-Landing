using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket07 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Renderer floorRenderer;


    public float mainEngineForce = 10f;
    public float leftEngineForce = 1f;
    public float rightEngineForce = 1f;


    public bool mainEngineOn = false;
    public bool leftEngineOn = false;
    public bool rightEngineOn = false;

    public GameObject mainEngineFx;
    public GameObject leftEngineFx;
    public GameObject rightEngineFx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            mainEngineOn = true;
        }
        else
        {
            mainEngineOn = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftEngineOn = true;
        }
        else
        {
            leftEngineOn = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightEngineOn = true;
        }
        else
        {
            rightEngineOn = false;
        }
    }

    private void FixedUpdate()
    {
        if (mainEngineOn)
        {
            rb.AddForceAtPosition(transform.up * mainEngineForce, transform.position);
            mainEngineFx.SetActive(true);
        }
        else
        {
            mainEngineFx.SetActive(false);
        }

        if (leftEngineOn)
        {
            rb.AddForceAtPosition(transform.right * leftEngineForce, leftEngineFx.transform.position);
        }

        if (rightEngineOn)
        {
            rb.AddForceAtPosition(-transform.right * rightEngineForce, rightEngineFx.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.y > 10f)
        {
            floorRenderer.material.color = Color.red;
        }
        else
        {
            floorRenderer.material.color = Color.green;
        }
    }
}
