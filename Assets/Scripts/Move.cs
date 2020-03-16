using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float speed;
    private float acceleration;
    public Vector2 originalDirection;
    private Vector2 directionVector;
    private Vector2 accelVector;
    private bool collided = false;
    private float variableSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = (Random.value) + 1;
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

    void OnTriggerStay2D(Collider2D collision){
        collided = true;
        Debug.Log("Collision detected "+collided);
        
    }

    void OnTriggerExit2D()
    {
        collided = false;
        Debug.Log("Exit Collision " + collided);

    }
}

//DETECTING PROXIMITY STUFF!
//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
