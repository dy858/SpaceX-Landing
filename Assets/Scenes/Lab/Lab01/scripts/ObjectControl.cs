using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float a = 0;
    // Update is called once per frame
    void Update()
    {
        Input.GetKey(KeyCode.Space);
        
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(a, transform.position.y, transform.position.z);
        }
        a = a + 0.5f;


    }
}
