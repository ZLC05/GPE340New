using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Default Data")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [Header("Events")]

    [Tooltip("When Taking Damage, Play this")] 
    public UnityEvent OnTakeDamage;

    [Tooltip("When dying, play this")]
    public UnityEvent OnDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageDone)
    {
        // Debug 
        Debug.Log("Damage has been dealt! " + damageDone);

        // Subtract damage from health
        currentHealth -= damageDone;

        //  Clamp health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //  Check for death
        if (currentHealth <= 0)
        {
            Die();
        }

        //When taking damage, invoke the function attached to the unity event
        OnTakeDamage.Invoke();
    }

    public void Die()
    {
        //Die lol
        Debug.Log(gameObject.name + " has died. ");
        //When dead, invoke the function(s) attached to the unity event
        OnDeath.Invoke();
    }
}
