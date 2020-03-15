using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float speed;
    private float acceleration;
    public Vector2 originalDirection;
    private Vector2 directionVector;

    // Start is called before the first frame update
    void Start()
    {
        speed = (Random.value) + 1;
        acceleration = 2f;

        float direction = transform.eulerAngles.z;
        Debug.Log("Found rotation: " + direction);
        switch (direction) {
            case 0:
                directionVector = Vector2.left;
                break;

            case 90:
                directionVector = Vector2.down;
                break;

            case 180:
                directionVector = Vector2.right;
                break;

            case 270:
                directionVector = Vector2.up;
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
        transform.position = (Vector2)transform.position + directionVector * speed * Time.deltaTime;



    }

    void OnCollisionStay2D(Collision2D collision){
        transform.position = (Vector2)transform.position + directionVector *(speed * Time.deltaTime - acceleration * (Mathf.Pow(Time.deltaTime,2))/2);
        Debug.Log("Collision detected");
    }
}

//DETECTING PROXIMITY STUFF!
//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
