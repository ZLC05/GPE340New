using UnityEngine;

public class CoupleExample : MonoBehaviour
{

    public delegate void TheDelegate();
    public TheDelegate OnCallEvent;

    public void Start()
    {
        OnCallEvent = DoStuff;
    }


    public void DoStuff()
    {
        //Mathches
        Debug.Log("Fuck");
    }

    public void Other(int x)
    {
        //doesnt
    }
       
}

