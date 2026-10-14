using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Animator))]
public class PawnHuman : Pawn
{
    [Header("Animation")]
    [Tooltip("Attach the animations to the pawn here")]
    public Animator anim;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //On start, get the player controller
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //For Debug, Draws a line where the player is looking at
        Debug.DrawRay(transform.position, transform.forward * 500, Color.red);
    }

    public void OnAnimatorMove()
    {
        //Tries to find the AI controller if there is one.
        AIController aiController = controller as AIController;


        // After the animation runs
        // Use root motion to move the game object
        transform.position = anim.rootPosition;
        transform.rotation = anim.rootRotation;


        // If there is a AI controller, activate this.
        if (aiController != null)
        {
            // Set our navMeshAgent to understand it is as the position from the animator
            aiController.agent.nextPosition = anim.rootPosition;
        }
    }
    public override void Move(Vector3 MoveDirection)
    {
        //Moves the pawn towards the direction of MoveDirection.
        MoveDirection = Vector3.ClampMagnitude(MoveDirection, 1) * moveSpeed;

        //Multiplies the direction by its move speed to go fast
        MoveDirection *= moveSpeed;
        
        //Triggers to actually move using the inputs and sets where the animation needs to go and play at what speed.
        MoveDirection = transform.InverseTransformDirection(MoveDirection);
        anim.SetFloat("Forward", MoveDirection.z);
        anim.SetFloat("Right", MoveDirection.x);

        //<summary>
        //Move towards a Direction based on the movement speed and the input and send that information to the animation controller to play the proper animations
        //</summary>

    }
    public override void UnPosses()
    {
        //Unposses a pawn
        controller.pawn = null;
        controller = null;
    }
    public override void Posses(Controller controller)
    {
        //make a controller posses this pawn
        controller.pawn = this;
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

    public void OnAnimatorIK(int layerIndex)
    {
        //Checks if weapon is active
        if(weapon == null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);


        }
        else
        {
            //Hands will do what the animation tells them
            if (weapon.rightHandPoint == null)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);

            }
            else
            {

                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

                anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
            }

            //Hands will do what the animation tells them
            if (weapon.leftHandPoint == null)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);

            }
            else
            {

                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

                anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
            }
        }
    }

}
