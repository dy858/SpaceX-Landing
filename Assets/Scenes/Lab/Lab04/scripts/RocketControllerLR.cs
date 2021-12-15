using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControllerLR : MonoBehaviour
{
    public Rigidbody rb;
    public AgentControllerLR ac;

    public float mainEngineforce = 20f;
    public float leftEngineforce = 1f;
    public float rightEngineforce = 1f;

    public bool mainEngineOn = false;
    public bool leftEngineOn = false;
    public bool rightEngineOn = false;

    public GameObject mainEngineFx;
    public GameObject leftEngineFx;
    public GameObject rightEngineFx;


    public Renderer floorRenderer;
    public bool reset = false;
    public bool stop = false;

    public float initHeight = 10;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AgentControllerLR>();
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


    private void FixedUpdate()
    {
        if (ac.episodeFinished)
        {
            return;
        }

        if (reset)
        {
            transform.localPosition = new Vector3(0, initHeight, 0);
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            reset = false;
            stop = false;
            floorRenderer.material.color = Color.white;
            return;
        }

        if(transform.localPosition.y > initHeight * 1.2 || transform.localPosition.y < 0)
        {
            floorRenderer.material.color = Color.red;
            ac.EndEpisode(0);
            return;
        }
        
        if (rb.IsSleeping())
        {
            
            if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.up)) > 0.9 && 
                Mathf.Abs(Vector3.Dot(transform.up, Vector3.right)) < 0.1 && 
                Mathf.Abs(Vector3.Dot(transform.up, Vector3.forward)) < 0.1)
            {
                floorRenderer.material.color = Color.green;
                ac.EndEpisode(1);

            }
            else
            {
                floorRenderer.material.color = Color.red;
                ac.EndEpisode(0);
            }
        }


        if (stop)
        {
            return;
        }

        if (mainEngineOn)
        {
            rb.AddForceAtPosition(transform.up * mainEngineforce, transform.position);
            mainEngineFx.SetActive(true);
        }
        else
        {
            mainEngineFx.SetActive(false);
        }

        if (leftEngineOn)
        {
            rb.AddForceAtPosition(transform.right * leftEngineforce, leftEngineFx.transform.position);
        }
        leftEngineFx.SetActive(leftEngineOn);
        if (rightEngineOn)
        {
            rb.AddForceAtPosition(-transform.right * rightEngineforce, rightEngineFx.transform.position);
        }
        rightEngineFx.SetActive(rightEngineOn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ac.episodeFinished || stop)
        {
            return;
        }

        if (collision.relativeVelocity.y > 10f)
        {
            floorRenderer.material.color = Color.red;
            ac.EndEpisode(0f);
        }
        else
        {
            stop = false;
        }
    }
}
