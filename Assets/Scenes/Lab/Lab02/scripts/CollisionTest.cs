using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public Renderer rd;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.y > 10)
        {
            rd.material.color = Color.red;
        }
        else
        {
            rd.material.color = Color.green;
        }

        Debug.Log(collision.relativeVelocity);
    }
}
