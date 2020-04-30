using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float speed;
    private float acceleration;
    private Vector2 directionVector;
    private Vector2 accelVector;
    private bool collided = false;
    private float variableSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        acceleration = 2f;
        variableSpeed = speed;

        float direction = transform.eulerAngles.z;
        Debug.Log("Found rotation: " + direction);
        switch (direction) {
            case 0:
                directionVector = Vector2.left;
                accelVector = Vector2.right;
                break;

            case 90:
                directionVector = Vector2.down;
                accelVector = Vector2.up;
                break;

            case 180:
                directionVector = Vector2.right;
                accelVector = Vector2.left;
                break;

            case 270:
                directionVector = Vector2.up;
                accelVector = Vector2.down;
                break;

            default:
                Debug.Log("No selection found for "+direction+" degrees.");
                break;
        }

        Debug.Log("Direction Assigned: " + directionVector);
    }

    // Update is called once per frame
    void Update()
    {
        if (collided == true && variableSpeed > 0) // collision detected
        {
            variableSpeed -= 0.025f;
        }
        else if (collided == true && variableSpeed <= 0)
        {
            variableSpeed = 0;
        }
        else if(collided == false && variableSpeed < speed)
        {
            variableSpeed += 0.025f;
            
        }
        else
        {
            variableSpeed = speed;
            
        }
            transform.position = (Vector2)transform.position + directionVector * variableSpeed * Time.deltaTime;
        


    }

    void OnTriggerStay2D(Collider2D collider){
        Vector2 colliderPosition = collider.attachedRigidbody.transform.position;
        Vector2 relativeDisplacement = new Vector2(0,0);
        float parallelPosition = 0;
        float normalPosition = 0;

        relativeDisplacement.x = transform.position.x - colliderPosition.x;
        relativeDisplacement.y = transform.position.y - colliderPosition.y;

        if(directionVector == Vector2.down)
        {
            parallelPosition = relativeDisplacement.y * -1;
            normalPosition = relativeDisplacement.x;
        }
        else if(directionVector == Vector2.up)
        {
            parallelPosition = relativeDisplacement.y;
            normalPosition = relativeDisplacement.x;
        }
        else if(directionVector == Vector2.right)
        {
            parallelPosition = relativeDisplacement.x;
            normalPosition = relativeDisplacement.y;
        }
        else if(directionVector == Vector2.left)
        {
            parallelPosition = relativeDisplacement.x * -1;
            normalPosition = relativeDisplacement.y;
        }
        

        if (parallelPosition < 0 && Mathf.Abs(normalPosition) < 0.7) { //Only if the car is behind the detected collider, and along the same trajectory, should the stopping condition activate
            collided = true;
            Debug.Log("Collision detected " + collided);
            Debug.Log("Relative Position " + relativeDisplacement);
        }
        
    }

    void OnTriggerExit2D()
    {
        collided = false;
        Debug.Log("Exit Collision " + collided);

    }
}

//DETECTING PROXIMITY STUFF!
//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
