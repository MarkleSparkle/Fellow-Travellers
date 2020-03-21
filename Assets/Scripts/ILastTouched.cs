using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILastTouched : MonoBehaviour
{

    public Collider iLastEntered;
    public Collider iLastExited;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        iLastEntered = col;
        //if the Collider the car just entered with is a BoxCollider, that means that it has gotten to close to the car behind it,
             //then decrease the speed of the car, as long as it is not still in collision with the car.
    }

    void OnTriggerExit(Collider col)
    {
        iLastExited = col;
        //if the Collider that you just exited was a BoxCollider (a car),
            //get the velocity of the object that you entered (because that would be the car in front of you)
            //that way, the current car can match the speed of the car in front, as long as it is not too close to the car
            //(meaning that the car's CapsuleCollider has collided with the car in front again).

    }

    //used https://www.youtube.com/watch?v=7GASazoHlck
    //and https://answers.unity.com/questions/736962/distinguish-between-multiple-box-colliders.html
    //and 
}