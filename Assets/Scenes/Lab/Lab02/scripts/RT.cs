using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT : MonoBehaviour
{
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward;
            
        }
        else
        {
            //키를 떼는 순간 멈추게 된다
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.angularVelocity = new Vector3(0, -1, 0);
        }
        else
        {
            //키를 떼는 순간 멈추게 된다
            rb.angularVelocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.angularVelocity = new Vector3(0, 1, 0);
        }
        else
        {
            //키를 떼는 순간 멈추게 된다
            rb.angularVelocity = Vector3.zero;
        }


    }
}
