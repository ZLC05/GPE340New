
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class ControllerPlayer : Controller
{
    public Camera playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }

    public override void MakeDecisions()
    {


        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        pawn.Move(moveVector);

        //TODO: find the point on the foot plan that the mouse is overlapping and rotate towards it;
        Plane footplane;
        footplane = new Plane(Vector3.up, pawn.transform.position);

        Vector2 mouspos = Mouse.current.position.value;

        Vector3 raySPRT = new Vector3(mouspos.x, mouspos.y, pawn.transform.position.z);

        Ray mouseRay;
        mouseRay = playerCam.ScreenPointToRay(raySPRT);

        float hitDistance;
        if(footplane.Raycast(mouseRay, out hitDistance))
        {
           //if we hit the plane
           Vector3 raycastHitPoint = mouseRay.GetPoint(hitDistance);

            //rotate to look at the point
            //go to pawn
            pawn.LookAtPoint(raycastHitPoint);
        }
        else
        {
            //do nothing
        }

    }


    //Posseses and Unposseses.
    public override void Posess(Pawn pawnToPosses)
    {
        base.Posess(pawnToPosses);
    }
    public override void UnPosess()
    {
        base.UnPosess();
    }
}
