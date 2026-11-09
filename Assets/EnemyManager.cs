using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(GameObject enemyPawnPrefab, Vector3 position, Quaternion roation, EnemyData data)
    {
        //spawn the enemy
        GameObject newEnemy = Instantiate(enemyPawnPrefab, position, roation);

        //check for components
        Pawn newEnemyPawn = newEnemy.GetComponent<Pawn>();
        Health enemyHealthComponent = newEnemy.GetComponent<Health>();
        //set the enemy data if EnemyData wass passed
        if (data != null)
        {
            //set enemy data
            //check if health != null if it doesnt, then assign the health
            if (enemyHealthComponent != null)
            {
 
                enemyHealthComponent.maxHealth = data.maxHealth;
                enemyHealthComponent.currentHealth = data.health;
            }

            //assign the movement data to the controller
            if(newEnemyPawn != null)
            {
                newEnemyPawn.moveSpeed = data.moveSpeed;
                newEnemyPawn.rotationSpeed = data.turnSpeed;
            }



            //if the data does have a assigned weapon, spawn the weapon and apply it
            if (data.weapon != null)
            { 
                newEnemyPawn.weapon = data.weapon;
            }


        }






        //add the enemy controller to the pawn
        AIController newEnemyController = newEnemy.AddComponent<AIController>();
        newEnemyController.Posess(newEnemyPawn);

        


    }








    public void SpawnEnemy()
    {

    }
}


public class EnemyData
{
    public float health;
    public float maxHealth;
    public Weapon weapon;
    public float moveSpeed;
    public float turnSpeed;
    
}
