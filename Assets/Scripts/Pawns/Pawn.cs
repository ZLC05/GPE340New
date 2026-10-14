using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [Header("Movement Speed")]
    [Tooltip("Adjust how fast the pawn moves")]
    public float moveSpeed; //Move speed of the pawn
    [Tooltip("Adjust how fast the pawn rotates")]
    public float rotationSpeed; // rotation speed of the pawn

    [Header("Pawn and Controller")]
    [Tooltip("Attach a AI controller/Player Controller here")]
    public Controller controller; // Connected controller (either AI or Player)
    [Tooltip("Attach THIS pawn here")]
    public Pawn pawn; //Yourself

    [Header("Weapons")]
    [Tooltip("Equipped Weapon")]
    public Weapon weapon;


    
    public abstract void Move(Vector3 moveVector); //Move towards the target
    public abstract void Rotate(float angle); //Rotate towards an angle
    public abstract void LookAtPoint(Vector3 position); //Rotate towards a target
    public abstract void Posses(Controller controller); // Posess a controller
    public abstract void UnPosses(); // Unpossess a controller;
}
