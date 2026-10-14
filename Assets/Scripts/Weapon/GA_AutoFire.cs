using UnityEngine;
using UnityEngine.Events;

public class GA_AutoFire : MonoBehaviour
{
    public bool isShooting;
    public float shotsPerSec;

    public UnityEvent OnShoot;
    private float lastShotTime;

    public void Start()
    {
        //pretend we just shot
        lastShotTime = Time.time - shotsPerSec;
    }

    public void Update()
    {
        //start shooting
        if (isShooting)
        {
            if(Time.time >= lastShotTime + shotsPerSec)
            {
                OnShoot.Invoke();
                lastShotTime = Time.time;
            }
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    
}
