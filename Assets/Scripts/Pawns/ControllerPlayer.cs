
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class ControllerPlayer : Controller
{
    public Camera playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        //nothing yet
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
        if (footplane.Raycast(mouseRay, out hitDistance))
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

        //Shooting!

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.weapon.OnPrimaryFireStart.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pawn.weapon.OnPrimaryFireEnd.Invoke();
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            pawn.weapon.OnSecondaryFireStart.Invoke();
        }
        //Add a Reload function



        //reactivate when changing the system
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.weapon.OnSecondaryFireStart.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pawn.weapon.OnSecondaryFireEnd.Invoke();
        }
        */
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
