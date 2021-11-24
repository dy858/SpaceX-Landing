using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Rigidbody rb;
    public AgentController ac;
    public Renderer floorRenderer;
    public float force = 20f;
    public bool engineOn = false;

    public Vector3 initialPosition = new Vector3(0, 10, 0);

    public bool reset = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AgentController>();
    }

    public void ResetRocket()
    {
        reset = true;
    }

    public void OnEngine()
    {
        engineOn = true;
    }

    public void OffEngine()
    {
        engineOn = false;
    }

    private void FixedUpdate()
    {
        if (ac.episodeFinished)
        {
            return;
        }

        if (reset)
        {
            transform.position = initialPosition;
            rb.velocity = Vector3.zero;

            reset = false;
            floorRenderer.material.color = Color.white;
            return;
        }

        if (engineOn)
        {
            rb.AddForce(Vector3.up * force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ac.episodeFinished)
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
            floorRenderer.material.color = Color.green;
            ac.EndEpisode(1f);
        }
    }
}
