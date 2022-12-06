﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;

public class Move : MonoBehaviour
{//this class now controls movement, proximity sensing, and despawn sequence

    private float speed;
    private float acceleration;
    private float stoppingDistance;
    private Vector2 distance;
    private Vector2 directionVector;
    private float variableSpeed;
    private float maxStoppingDistance;
    private float angerGeneration;
    private float angerPoints = 0f;
    public angerBarManager angerManagement;
    private AudioSource exhaustSound;
    private bool fadeIn;

    //the popup prefab that shows the anger added
    public Text PopupText;
    private bool volume;

    void Start()
    {
        exhaustSound = gameObject.GetComponent<AudioSource>();
        FadeIn();


        speed = 1.5f;//initialize kinematic variables
        acceleration = speed/1.2f;
        variableSpeed = speed;

        //set up communication with anger slider script
        angerManagement = GameObject.FindObjectOfType<angerBarManager>();
        
        float direction = transform.eulerAngles.z;
        //Debug.Log("Found rotation: " + direction);
        switch (direction) {
            case 90:
                directionVector = Vector2.left;
                
                break;

            case 180:
                directionVector = Vector2.down;
                
                break;

            case 270:
                directionVector = Vector2.right;
                
                break;

            case 0:
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

        angerGeneration = 0.05f * Time.timeScale;

        int layerMask = Physics2D.DefaultRaycastLayers;
        Vector2 origin = (Vector2)transform.position + 0.6f*directionVector;//raycasts must originate in front of the car's hit box so it does not detect itself

        maxStoppingDistance = 1.6f;

        // **Ray Casting Object Detection**

        RaycastHit2D cast = Physics2D.Raycast(origin, directionVector, maxStoppingDistance, layerMask, 0, 0.5f);
        Debug.DrawRay(origin, (directionVector*maxStoppingDistance), Color.red);

        if (cast.collider != null && variableSpeed > 0)// If ray detects an object and the vehicle has not come to a complete stop
        {
            distance = (Vector2)cast.collider.transform.position - (Vector2)transform.position; //proximity-based deceleration, so cars have an appropriate stopping distance
            stoppingDistance = distance.magnitude - 0.1f;
            acceleration = (Mathf.Pow(speed, 2f))/ (2 * stoppingDistance);
            variableSpeed -= (acceleration*Time.deltaTime);
            // Debug.Log("raycast hit body "+ cast.rigidbody + "raycast hit collider "+ cast.collider);
            angerPoints = angerGeneration;
            angerManagement.addAnger(angerPoints);
        }
        else if (cast.collider != null && variableSpeed <= 0.05)// If ray detects an object and vehicle is (essentially) at a complete stop
        {// Vehicle stays stopped while rays detects another object. Anger points are generated while at a complete stop
            variableSpeed = 0;
            angerPoints = angerGeneration;
            angerManagement.addAnger(angerPoints);
        }
        else if(cast.collider == null && variableSpeed < speed)// If ray no longer detects an object the vehicle re-accelerates
        {
            variableSpeed += 0.025f;

        }
        else //Constant speed in the absence of obstructions
        {
            variableSpeed = speed;
        }

            transform.position = (Vector2)transform.position + directionVector * variableSpeed * Time.deltaTime;


        // **Position-based Vehicle Despawning**

        if (transform.position.x > horizontalMax && directionVector == Vector2.right)
        {
            FadeOut();
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

        if (fadeIn)
        {
            if (exhaustSound.volume >= 0.05f) //volume at correct volume
            {
                fadeIn = false;
            }
            else
            {
                exhaustSound.volume += 0.005f;
            }
        }
    }

    void FadeIn()
    {
        exhaustSound.volume = 0;
        fadeIn = true;
        exhaustSound.Play();
    }

    void FadeOut()
    {
        exhaustSound.volume = 0;
        exhaustSound.Stop();
    }
}

//DETECTING PROXIMITY STUFF!
//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
