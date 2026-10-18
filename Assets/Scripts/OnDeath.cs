using UnityEngine;

public class OnDeath : MonoBehaviour
{

    public GameObject particles;
 
    public void OnDeathParticleSystem()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(particles, 5);

        Destroy(this.gameObject);
        
    }
}
