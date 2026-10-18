using UnityEngine;

public class GA_TVSniper : GameAction
{

    [Tooltip("Where the ray Starts")]
    public Transform firepoint;

    [Tooltip("How far the ray fires.")]
    public float fireDistance;

    [Tooltip("Damage the weapon deals")]
    public float damageDone;

    [Tooltip("How fast the weapon fires")]
    public float fireRate;

    [Tooltip("Visuals of the Laserbeam")]
    public LaserVisuals laserData;

    [Tooltip("The Laserbeam that shoots out")]
    public GameObject laserBeamPrefab;
    
    



    public void Shoot()
    {
        //Create a raycast to hold the data
        RaycastHit hit;

        //Summons the laserbeam
        GameObject BeamObj = Instantiate(laserBeamPrefab, firepoint.position, firepoint.rotation);
        LaserBeam theBeam = BeamObj.GetComponent<LaserBeam>();

        //Sets the data
        theBeam.color = laserData.color;
        theBeam.width = laserData.width;
        theBeam.lifespan = laserData.lifespan;
        theBeam.startPoint = firepoint.position;
        theBeam.endPoint = firepoint.position + (firepoint.forward * fireDistance);




        //Activate the raycast
        if (Physics.Raycast(firepoint.position, firepoint.forward, out hit, fireDistance))
        {
            //Get the health component and deal damage to the enemy
            Health healthComponent = hit.collider.GetComponent<Health>();
            //checks to see if health component exists on the colidded object
            if (healthComponent != null)
            {
                //Take the damage
                healthComponent.TakeDamage(damageDone);
            }
            Debug.Log(hit.transform.gameObject);

            //Health or no health, limit the endpoint
            theBeam.endPoint = hit.point;
        }




    }

    public void SecondaryShoot()
    {
        GA_Ammo ammo = GetComponent<GA_Ammo>();
        int multiplier = ammo.ammo/ammo.ammoPerShot;
         Debug.Log(multiplier);

        //Create a raycast to hold the data
        RaycastHit hit;

        //Summons the laserbeam
        GameObject BeamObj = Instantiate(laserBeamPrefab, firepoint.position, firepoint.rotation);
        LaserBeam theBeam = BeamObj.GetComponent<LaserBeam>();

        //Sets the data
        theBeam.color = laserData.color;
        theBeam.width = laserData.width * multiplier;
        theBeam.lifespan = laserData.lifespan;
        theBeam.startPoint = firepoint.position;
        theBeam.endPoint = firepoint.position + ((firepoint.forward * fireDistance) * multiplier);




        //Activate the raycast
        if (Physics.Raycast(firepoint.position, firepoint.forward, out hit, fireDistance))
        {
            //Get the health component and deal damage to the enemy
            Health healthComponent = hit.collider.GetComponent<Health>();
            //checks to see if health component exists on the colidded object
            if (healthComponent != null)
            {
                //Take the damage
                healthComponent.TakeDamage(damageDone * multiplier);
            }
            Debug.Log(hit.transform.gameObject);

            //Health or no health, limit the endpoint
            theBeam.endPoint = hit.point;
        }
    }

}

[System.Serializable]
public class LaserVisuals
{
    public Vector3 startPoint;
    public Color color = Color.white;
    public float lifespan = 0.1f;
    public float width = 0.5f;

}