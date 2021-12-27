using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControllerFinal : MonoBehaviour
{
    public Rigidbody rb;
    public AgentControllerFinal ac;

    public float mainEngineForce = 20f;
    public float sideEngineForce = 1f;

    public bool mainEngineOn = false;
    public bool leftEngineOn = false;
    public bool rightEngineOn = false;
    public bool forwardEngineOn = false;
    public bool backwardEngineOn = false;

    public bool reset = false;
    public bool stop = false;

    public GameObject landingZoneNormal;
    public GameObject landingZoneSuccess;
    public GameObject landingZoneFail;

    public float initHeight = 10f;
    public float rotationRange = 0f;
    public float xzRange = 0f;


    void Start()
    {
        ac = GetComponent<AgentControllerFinal>();
        rb = GetComponent<Rigidbody>();
    }

    public void ResetRocket()
    {
        reset = true;
    }

    public void SetMainEngine(int value)
    {
        if (value == 1)
        {
            mainEngineOn = true;
        }
        else
        {
            mainEngineOn = false;
        }
    }

    public void SetLeftEngine(int value)
    {
        if (value == 1)
        {
            leftEngineOn = true;
        }
        else
        {
            leftEngineOn = false;
        }
    }

    public void SetRightEngine(int value)
    {
        if (value == 1)
        {
            rightEngineOn = true;
        }
        else
        {
            rightngineOn = false;
        }
    }

    public void SetForwardEngine(int value)
    {
        forwardEngineOn = (value == 1);
    }

    public void SetbackwardEngine(int value)
    {
        backwardEngineOn = (value == 1);
    }

    private void FixedUpdate()
    {
        if (ac.episodeFinished)
        {
            return;
        }

        if (reset)
        {
            transform.position = new Vector3(Random.Range(-xzRange, xzRange), initHeight,
                Random.Range(-xzRange, xzRange));
            transform.rotation = Quaternion.Euler(
                new Vector3(
                Random.Range(-rotationRange, rotationRange),
                Random.Range(-rotationRange, rotationRange),
                Random.Range(-rotationRange, rotationRange)
                )
                );

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            reset = false;
            stop = false;

            landingZoneNormal.SetActive(true);
            landingZoneSuccess.SetActive(false);
            landingZoneFail.SetActive(false);


        }

        if(transform.position.y > initHeight*1.2f || transform.position.y < 0)
        {
            landingZoneNormal.SetActive(false);
            landingZoneSuccess.SetActive(false);
            landingZoneFail.SetActive(true);
        }


    }



}
