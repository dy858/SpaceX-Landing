using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingLegTest : MonoBehaviour
{
    public GameObject rocket;

    public GameObject leg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float h = rocket.transform.position.y;
        
        if(h>=4 && h<= 10){
            h -= 4;
            h = 6 - h;
            h *= 20;

            leg.transform.localRotation = Quaternion.Euler(new Vector3(0, h, 0));
        }

        else if(h > 10)
        {
            leg.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        else if(h < 4)
        {
            leg.transform.localRotation = Quaternion.Euler(new Vector3(0, 120, 0));
        }

        
        leg.transform.localRotation = Quaternion.Euler(new Vector3(0, (6 - (Mathf.Clamp(h, 4, 10) - 4)) * 20, 0));


    }
}
