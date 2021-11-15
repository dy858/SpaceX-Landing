using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTest : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1f;
    public Transform RightCube;
    public Transform LeftCube;
    public Transform UpCube;
    public Transform DownCube;



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
            rb.AddForce(transform.up * force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForceAtPosition(transform.right * force, RightCube.position );
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForceAtPosition(-transform.right * force, LeftCube.position );
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForceAtPosition(transform.up * force, UpCube.position );
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForceAtPosition(transform.up * force, DownCube.position );
        }

    }
}
