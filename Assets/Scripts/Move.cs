﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{//this class now controls movement, proximity sensing, and despawn sequence

    private float speed;
    private float acceleration;
    private Vector2 directionVector;
    private float variableSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        acceleration = speed/1.2f;
        variableSpeed = speed;

        float direction = transform.eulerAngles.z;
        //Debug.Log("Found rotation: " + direction);
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

        //Debug.Log("Direction Assigned: " + directionVector);
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;//redeclaring these in this script so that cars know when to despawn
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        float horizontalMin = -halfWidth - 1.2f;
        float horizontalMax = halfWidth + 1.2f;
        float verticalMin = -halfHeight - 1.2f;
        float verticalMax = halfHeight + 1.2f;

        float stoppingDistance = 1.2f;
        int layerMask = Physics2D.DefaultRaycastLayers;
        Vector2 origin = (Vector2)transform.position + directionVector;

        RaycastHit2D cast = Physics2D.Raycast(origin, directionVector, stoppingDistance, layerMask, 0, 0.5f);
        Debug.DrawRay(origin, directionVector, Color.red);

        if (cast.collider != null && variableSpeed > 0)
        {
            variableSpeed -= 0.1f;
            Debug.Log("raycast hit body "+ cast.rigidbody + "raycast hit collider "+ cast.collider);
        }
        else if (cast.collider != null && variableSpeed <= 0)
        {
            variableSpeed = 0;
        }
        else if(cast.collider == null && variableSpeed < speed)
        {
            variableSpeed += 0.025f;
            
        }
        else
        {
            variableSpeed = speed;
            
        }

            transform.position = (Vector2)transform.position + directionVector * variableSpeed * Time.deltaTime;

        //cars will now despawn themsevles from their own move scripts
        if (transform.position.x > horizontalMax && directionVector == Vector2.right)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < horizontalMin && directionVector == Vector2.left)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > verticalMax && directionVector == Vector2.up)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < verticalMin && directionVector == Vector2.down)
        {
            Destroy(gameObject);
        }


    }

    
}

//DETECTING PROXIMITY STUFF!
//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
