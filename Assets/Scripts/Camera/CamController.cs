using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamController : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;


    // Update is called once per frame
    void Update()
    {
        //Find where the camera wants to be (the distance is the offset)
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + distance, target.position.z);

        //Move the camera towards the location
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);


        //Look at the target
        transform.LookAt(target.position, target.forward);
    }
}
