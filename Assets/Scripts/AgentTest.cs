using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentTest : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetTransform.position);


        Vector3 desiredVelocity = agent.desiredVelocity;

        desiredVelocity = transform.InverseTransformDirection(desiredVelocity);

        float tempSpeedDeleteMe = 3;
        desiredVelocity = desiredVelocity.normalized * tempSpeedDeleteMe;

        anim.SetFloat("Forward", desiredVelocity.z);
        anim.SetFloat("Right", desiredVelocity.x);

        Quaternion rotationToMovementDirection = Quaternion.LookRotation(agent.desiredVelocity, Vector3.up);

        float maxRotateSpeedTempDELETEME = 360;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMovementDirection,
                                                                   maxRotateSpeedTempDELETEME * Time.deltaTime);
    }

    private void OnAnimatorMove()
    {
        agent.velocity = anim.velocity;
    }
}
