using UnityEngine;

public class GA_WeaponFIreSound : MonoBehaviour
{
    public AudioSource weaponFire;

    public void playSound()
    {
        weaponFire.Play();
    }
}
