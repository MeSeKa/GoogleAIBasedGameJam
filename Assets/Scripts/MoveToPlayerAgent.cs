using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.Sentis.Layers;

public class MoveToPlayerAgent : Agent
{

    [SerializeField] private Transform targetPosition;
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform targetSpawnPosition;


    [SerializeField] private Renderer environment;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;

    [SerializeField]
    private Rigidbody body;

    [SerializeField] private Animator animator;
    public override void OnEpisodeBegin()
    {
        transform.position = spawnPosition.position;
        targetPosition.position = targetSpawnPosition.position;
        //targetPosition.GetComponent<RandomPlayerMovement>().SetCanMove(true);

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if(transform)
        sensor.AddObservation(transform.position);
        if(targetPosition)
        sensor.AddObservation(targetPosition.position);

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        //transform.Translate(new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime);
        body.velocity = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        body.velocity = body.velocity.normalized * moveSpeed;

        Vector3 lookRotation = targetPosition.position - transform.position;
        lookRotation.y = 0;
        transform.forward = lookRotation;

        animator.SetFloat("MoveSpeed", body.velocity.magnitude);
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continousActions = actionsOut.ContinuousActions;

        continousActions[0] = Input.GetAxisRaw("Horizontal");
        continousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetReward(1);
            environment.sharedMaterial = winMaterial;
            SceneTransitionManager.Instance.EndScene();
            EndEpisode();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            SetReward(-1);
            environment.sharedMaterial = loseMaterial;
            EndEpisode();
        }
    }

}
