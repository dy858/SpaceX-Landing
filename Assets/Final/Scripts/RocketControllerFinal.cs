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

    public GameObject mainEngineFx;
    public GameObject leftEngineFx;
    public GameObject rightEngineFx;
    public GameObject forwardEngineFx;
    public GameObject backwardEngineFx;

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
            rightEngineOn = false;
        }
    }

    public void SetForwardEngine(int value)
    {
        forwardEngineOn = (value == 1);
    }

    public void SetBackwardEngine(int value)
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

            ac.EndEpisode(0);
            return;
        }
        if (rb.IsSleeping())
        {
            if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.up)) > 0.9 &&
                Mathf.Abs(Vector3.Dot(transform.up, Vector3.right)) < 0.1 &&
                Mathf.Abs(Vector3.Dot(transform.up, Vector3.forward)) < 0.1)
            {
                float distance = Vector3.Distance(landingZoneNormal.transform.position, new Vector3(transform.position.x, landingZoneNormal.transform.position.y, transform.position.z));

                if(distance < 3f)
                {
                    landingZoneNormal.SetActive(false);
                    landingZoneSuccess.SetActive(true);
                    landingZoneFail.SetActive(false);
                    //ac.EndEpisode(1f - distance / 3f);
                    ac.EndEpisode(1f);

                }
                else
                {
                    landingZoneNormal.SetActive(false);
                    landingZoneSuccess.SetActive(false);
                    landingZoneFail.SetActive(true);
                    //ac.EndEpisode(1f - distance / 3f);
                    ac.EndEpisode(0);
                }
            }
            else
            {
                landingZoneNormal.SetActive(false);
                landingZoneSuccess.SetActive(false);
                landingZoneFail.SetActive(true);
                ac.EndEpisode(0);
            }
        }


        if (stop)
        {
            return;
        }

        if (mainEngineOn)
        {
            rb.AddForceAtPosition(transform.up * mainEngineForce, transform.position);
        }
        else
        {

        }
        if (leftEngineOn)
        {
            rb.AddForceAtPosition(transform.right * sideEngineForce, leftEngineFx.transform.position);
        }

        else
        {

        }
        if (rightEngineOn)
        {
            rb.AddForceAtPosition(-transform.right * sideEngineForce, rightEngineFx.transform.position);
        }
        else
        {

        }
        if (forwardEngineOn)
        {
            rb.AddForceAtPosition(-transform.forward * sideEngineForce, forwardEngineFx.transform.position);
        }
        else
        {

        }

        if (backwardEngineOn)
        {
            rb.AddForceAtPosition(transform.forward * sideEngineForce, backwardEngineFx.transform.position);
        }
        else
        {

        }



    }

    void OnCollisionEnter(Collision collision)
    {
        if (ac.episodeFinished || stop)
        {
            return;
        }

        //Debug.Log(collision.relativeVelocity);
        if (collision.relativeVelocity.y > 10f)
        {
            landingZoneNormal.SetActive(false);
            landingZoneSuccess.SetActive(false);
            landingZoneFail.SetActive(true);
            ac.EndEpisode(0);
        }
        else
        {
            stop = true;
        }
    }



}
