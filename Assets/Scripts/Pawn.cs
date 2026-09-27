using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Controller controller;
    public Pawn pawn;
    public abstract void Move(Vector3 moveVector);
    public abstract void Rotate(float angle);
    public abstract void LookAtPoint(Vector3 position);
    public abstract void Posses(Controller controller);
    public abstract void UnPosses();
}
