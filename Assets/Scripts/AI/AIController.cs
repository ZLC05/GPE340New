using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    public NavMeshAgent agent;
    public float stoppingDistance;
    public Transform targetTransform;
    private Vector3 desiredVelocity = Vector3.zero;

    

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ControllerPlayer player = FindFirstObjectByType<ControllerPlayer>();
        targetTransform = player.pawn.transform;
    }

    public override void Posess(Pawn pawnToPossess)
    {
        // Set the variables (from the base class's definition)
        base.Posess(pawnToPossess);

        if(agent == null)
        {
            agent = pawn.GetComponent<NavMeshAgent>();
        }


        // Set the stopping distance
        agent.stoppingDistance = stoppingDistance;

        // Set the max speed of the AI from the pawn data
        agent.speed = pawn.moveSpeed;

        // Set the max rotation speed of the AI from the pawn data
        agent.angularSpeed = pawn.rotationSpeed;

        // Disable movement and rotation from the NavMeshAgent
        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    public override void UnPosess()
    {
        // Remove the NavMeshAgent
        Destroy(agent);

        // Set the variables (from the base class's definition)
        base.UnPosess();
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Do what all controllers do each frame (Make Decisions)
        base.Update();
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        
        // If we don't have a pawn, we can't make decisions for it, so do nothing
        if (pawn == null)
        {
            
            return;
            
        }

        if(targetTransform != null)
        {
            //make decisions and seek the target

            //if close enough to the player, start shooting(extra for LOS check
            if(pawn.weapon != null)
            {
                TryShoot();
            }
            
        }

        // Set our NavMeshAgent to seek our target
        agent.SetDestination(targetTransform.position);

        // Find the velocity that the agent wants to move in order to follow the path
        desiredVelocity = agent.desiredVelocity;

        // Send the direction in to our Move function (use the move function to add speed)
        pawn.Move(desiredVelocity.normalized);

        // Look towards the player
        pawn.LookAtPoint(targetTransform.position);
    }

    public virtual void TryShoot()
    {
        
        if(Vector3.Distance(pawn.transform.position, targetTransform.position) <= stoppingDistance)
        {
            Vector3 vectorToTarget = targetTransform.position - pawn.transform.position;
            float angleToTarget = Vector3.Angle(pawn.transform.forward, vectorToTarget);

           pawn.weapon.StartPrimaryFire();

            

        }
        else
        {
            pawn.weapon.EndPrimaryFire();
        }
    }
}
