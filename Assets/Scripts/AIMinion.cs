using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinion : AIController
{

    private Pawn pawn;
    private NavMeshAgent agent;
    public float maxShootingError = 0.1f;
    public float minShootDistance = 1.0f;
    public float maxShootDistance = 5.0f;

    private PlayerController Player;
    // Start is called before the first frame update

    public float noLeadDistance = 0.0f;
    public float maxLeadDistance = 25;

    private Vector3 leadVector; //how far in front of( or otherwise away from) player to shoot.

    public float leadModifier = 1.0f;

    public override void Awake()
    {
        //load components 
        pawn = GetComponent<Pawn>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override void Start()
    {
        if (Player == null)
        {
            FindPlayer();
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Player == null)
        {
            FindPlayer();
        }
        else
        {
            SetLeadVector();
            MoveToPlayer();
            RotateTowardsPlayer();
            if (pawn.weapon != null)
            {
                ShootAtPlayer();
            }
        }

    }

    public void RotateTowardsPlayer()
    {
        //find vector to player
        Vector3 vectorToPlayer = (Player.pawn.transform.position + leadVector) - pawn.transform.position;
        //find quaternion that is looking down at that vector
        Quaternion lookRotation = Quaternion.LookRotation(vectorToPlayer, Vector3.up);
        //Rotate a little bit towards that rotation
        pawn.transform.rotation = Quaternion.RotateTowards(pawn.transform.rotation, lookRotation, pawn.rotateSpeed * Time.deltaTime);


    }
    public void SetLeadVector()
    {
        //find distance to player
        float distanceToPlayer = Vector3.Distance(Player.transform.position, pawn.transform.position);
        //clamp that distance between our zero lead and max lead distances
        distanceToPlayer = Mathf.Clamp(distanceToPlayer, noLeadDistance, maxLeadDistance);

        float dTPFromMin = distanceToPlayer - noLeadDistance;
        float totalLeadDistanceRange = maxLeadDistance - noLeadDistance;
        //find what percent of the total range I currently am
        float percentOfLeadDistanceRange = dTPFromMin / totalLeadDistanceRange;
        //now that i have the range I can multiply my lead modifier by it
        //find a few seconds in front of the player
        leadVector = Player.pawn.anim.velocity * (leadModifier * percentOfLeadDistanceRange);
    }

    public void ShootAtPlayer()
    {
        float distanceToPlayer = Vector3.Distance(Player.transform.position, pawn.transform.position);

        if (distanceToPlayer > minShootDistance && distanceToPlayer < maxShootDistance)
        {
            float shootingError = Random.Range(-maxShootingError * 0.5f, maxShootingError * 0.5f);
            pawn.weapon.transform.Rotate(0, shootingError, 0);
            //shoot
            pawn.weapon.Shoot();
            //rotate back
            pawn.weapon.transform.Rotate(0, -shootingError, 0);
        }




    }

    public void FindPlayer()
    {
        Player = FindObjectOfType<PlayerController>();
    }
    public void MoveToPlayer()
    {
        agent.SetDestination(Player.pawn.transform.position);

        Vector3 desiredMovement = agent.desiredVelocity;

        desiredMovement = desiredMovement.normalized * pawn.moveSpeed;

        pawn.anim.SetFloat("Forward", desiredMovement.z);
        pawn.anim.SetFloat("Right", desiredMovement.x);
    }

    public void OnAnimatorMove()
    {
        agent.velocity = pawn.anim.velocity;
    }
}
