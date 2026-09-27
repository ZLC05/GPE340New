using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Animator))]
public class PawnHuman : Pawn
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 500, Color.red);
    }

    public void OnAnimatorMove()
    {
        AIController aiController = controller as AIController;
        // After the animation runs
        // Use root motion to move the game object
        transform.position = anim.rootPosition;
        transform.rotation = anim.rootRotation;

        // If we have a NavMeshAgent on our controller,

        if (aiController != null)
        {
            // Set our navMeshAgent to understand it is as the position from the animator
            aiController.agent.nextPosition = anim.rootPosition;
        }
    }
    public override void Move(Vector3 MoveDirection)
    {
       


        

            MoveDirection = Vector3.ClampMagnitude(MoveDirection, 1) * moveSpeed;

            MoveDirection *= moveSpeed;
            //sets the movements of the perametors allowing for the objects to update


            MoveDirection = transform.InverseTransformDirection(MoveDirection);
            anim.SetFloat("Forward", MoveDirection.z);
            anim.SetFloat("Right", MoveDirection.x);
        
    }
    public override void UnPosses()
    {
        controller.pawn = null;
        controller = null;
    }
    public override void Posses(Controller controller)
    {
        controller.pawn = this;
       // controller = controller.pawn;
    }
    public override void LookAtPoint(Vector3 position)
    {
        // Find the vector from our position to the target point
        Vector3 lookVector = position - transform.position;

        // Find the rotation that will look down that vector with world up being the up direction
        Quaternion lookRotation = Quaternion.LookRotation(lookVector, Vector3.up);

        // Rotate slightly towards that target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
    public override void Rotate(float angle)
    {
        //nothing rn
    }

}
