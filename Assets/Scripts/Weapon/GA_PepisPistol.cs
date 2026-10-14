using UnityEngine;

public class GA_PepisPistol : MonoBehaviour
{
    [Tooltip("Whats le max range")]
    public float fireDistance;
    [Tooltip("Where the Pepis Apears")]
    public Transform firePoint;
    [Tooltip("The Pepis Object Themselfs")]
    public GameObject pepisBullet;
    [Tooltip("Cooldown TIme before next fire")]
    public float fireRate;
    [Tooltip("Force applied to the pepis")]
    public float appliedForce;

    private bool AutoFire;


    public void Shoot()
    {
        GameObject thePepis = Instantiate<GameObject>(pepisBullet, transform.position, transform.rotation);
        //get the gameobject of the pepis and add force from the script here

        


        //Shoot out a Pepis Bullet and add force to it. Inside of the Pepis Script,
        //make it explode and deal damage to all enemys nearby
        //extra points if you scale the damage based on how far away they are from the explosion.
    }
}
