using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHP;
    [SerializeField] private float maxHP;

    public delegate void HealthDelegate(Pawn pawn, float damage);
    public HealthDelegate OnTakeDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnTakeDamage = TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(Pawn temp, float damage)
    {

    }
}
