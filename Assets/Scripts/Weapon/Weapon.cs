using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Inverse Kinematics")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    [Header("Unity Events")]
    public UnityEvent OnEquip;
    public UnityEvent OnUnEquip;
    public UnityEvent OnPrimaryFireStart;
    public UnityEvent OnPrimaryFireEnd;
    public UnityEvent OnSecondaryFireStart;
    public UnityEvent OnSecondaryFireEnd;


    //Unity Events Invoke Functions

    public void Equip()
    {
        OnEquip.Invoke();
    }

    public void Unequip()
    {
        OnUnEquip.Invoke();
    }

    public void StartPrimaryFire()
    {
        OnPrimaryFireStart.Invoke();
    }

    public void EndPrimaryFire()
    {
        OnPrimaryFireEnd.Invoke();
    }

    public void StartSecondaryFire()
    {
        OnSecondaryFireEnd.Invoke();
    }

    public void EndSecondaryFire()
    {
        OnSecondaryFireEnd.Invoke();
    }
}
