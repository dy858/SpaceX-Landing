using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(2, 2, 2);
            transform.rotation = Quaternion.Euler(45, 0, 0);
            transform.localScale = new Vector3(2, 1, 1);
        
    }
}
