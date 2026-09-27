using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public Controller controller;

    protected virtual void Start()
    {
        //if given a pawn at start, posess it
        if(pawn != null)
        {
            Posess(pawn);
        }
    }

    protected virtual void Update()
    {
        MakeDecisions();
    }

    public abstract void MakeDecisions();

    public virtual void Posess(Pawn pawnToPosses)
    {
        //ad a pawn that is in control
        pawn = pawnToPosses;

        pawn.controller = this;
    }
    public virtual void UnPosess()
    {
        //completly remove the pawn that is in control
        pawn.controller = null;

        pawn = null;
    }
}
