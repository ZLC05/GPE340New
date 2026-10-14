using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class GA_Ammo : MonoBehaviour
{
    [SerializeField] private int ammo;
    [SerializeField] private int ammoPerShot;
    [SerializeField] private int maxAmmo;
    public UnityEvent OnSuccess;
    public UnityEvent OnFail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryToShoot()
    {
        if(ammo >= ammoPerShot)
        {
            ammo -= ammoPerShot;
            OnSuccess.Invoke();
        }
        else
        {
            OnFail.Invoke();
        }
    }



    public void SubtractAmmo(int ammoToLose)
    {
        ammo -= ammoToLose;
        ammo = Mathf.Clamp(ammo, 0, maxAmmo);
    }


    public void AddAmmo(int ammoAdding)
    {
        ammo += ammoAdding;
        ammo = Mathf.Clamp(ammo, 0, maxAmmo);
    }
}
