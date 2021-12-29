using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AgentControllerFinal : Agent
{
    public RocketControllerFinal rc;
    public bool episodeFinished = false;

    public override void Initialize()
    {
        rc = GetComponent<RocketControllerFinal>();
    }

    public override void OnEpisodeBegin()
    {
        rc.ResetRocket();
        episodeFinished = false;
    }

    public override void CollectObservations(VectorSensor sensor) //나의 현재상태를 알려주는 함수
    {
        Vector3 rocketPosition = rc.transform.position;
        Vector3 rocketRotation = rc.transform.rotation.eulerAngles;

        Vector3 rocketVelocity = rc.rb.velocity;
        Vector3 rocketAngularVelocity = rc.rb.angularVelocity;

        sensor.AddObservation(rocketPosition.x);
        sensor.AddObservation(rocketPosition.y);
        sensor.AddObservation(rocketPosition.z);

        sensor.AddObservation(rocketRotation.x);
        sensor.AddObservation(rocketRotation.y);
        sensor.AddObservation(rocketRotation.z);

        sensor.AddObservation(rocketVelocity.x);
        sensor.AddObservation(rocketVelocity.y);
        sensor.AddObservation(rocketVelocity.z);

        sensor.AddObservation(rocketAngularVelocity.x);
        sensor.AddObservation(rocketAngularVelocity.y);
        sensor.AddObservation(rocketAngularVelocity.z);

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        rc.SetMainEngine(actions.DiscreteActions[0]);
        rc.SetLeftEngine(actions.DiscreteActions[1]);
        rc.SetRightEngine(actions.DiscreteActions[2]);
        rc.SetForwardEngine(actions.DiscreteActions[3]);
        rc.SetBackwardEngine(actions.DiscreteActions[4]);
    }

    public void EndEpisode(float reward)
    {
        SetReward(reward);

        episodeFinished = true;
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var actions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.Space))
        {
            actions[0] = 1;
        }

        else
        {
            actions[0] = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            actions[1] = 1;
        }

        else
        {
            actions[1] = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            actions[2] = 1;
        }

        else
        {
            actions[2] = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            actions[3] = 1;
        }

        else
        {
            actions[3] = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            actions[4] = 1;
        }

        else
        {
            actions[4] = 0;
        }
    }



}
