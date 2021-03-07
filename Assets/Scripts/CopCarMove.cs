using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCarMove : MonoBehaviour
{
    private float speed;
    private float acceleration;
    private float stoppingDistance;
    private Vector2 distance;
    private Vector2 directionVector;
    private float variableSpeed;
    private float maxStoppingDistance;
    private Vector2 offsetDirection;
    private Vector2 offsetCastOrigin;
    private float offset;
    private float maxOffset;
    private float minOffset;
    private float median;
    private float offsetSpeed;
    private float variableOffsetSpeed;
    private float offsetAcceleration;
    private float targetOffset;
    private float elapsedOffset;

    bool laneChange;

    void Start()
    {
        //initialize kinematic state variables
        speed = 1.8f;
        acceleration = speed / 1.5f;
        variableSpeed = speed;
        offsetSpeed = 0.5f;
        variableOffsetSpeed = 0;
        offsetAcceleration = offsetSpeed / 2;
        maxStoppingDistance = 1.6f;
        laneChange = false;
        targetOffset = 1;

        float direction = transform.eulerAngles.z;
        //Debug.Log("Found rotation: " + direction);
        switch (direction)
        {
            case 90:
                directionVector = Vector2.left;
                offsetDirection = Vector2.up;
                offset = transform.position.y;
                maxOffset = 1.7f;
                minOffset = 0.4f;
                median = 0.8f;
                break;

            case 180:
                directionVector = Vector2.down;
                offsetDirection = Vector2.right;
                offset = transform.position.x;
                maxOffset = -1.6f;
                minOffset = -0.6f;
                median = -1f;
                break;

            case 270:
                directionVector = Vector2.right;
                offsetDirection = Vector2.down;
                offset = transform.position.y;
                maxOffset = -1.7f;
                minOffset = -0.4f;
                median = -1.2f;
                break;

            case 0:
                directionVector = Vector2.up;
                offsetDirection = Vector2.left;
                offset = transform.position.x;
                maxOffset = 1.6f;
                minOffset = 0.6f;
                median = 1f;
                break;

            default:
                Debug.Log("No selection found for " + direction + " degrees.");
                break;

                
        }

        //Debug.Log("Direction Assigned: " + directionVector);

        if (Mathf.Abs(offset - median) < 0)
        {
            offsetDirection = -1 * offsetDirection; // reverse offset
            targetOffset = minOffset;
        }
        else
        {
            targetOffset = maxOffset;
        }


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

        int layerMask = Physics2D.DefaultRaycastLayers;
        Vector2 origin = (Vector2)transform.position + 0.6f * directionVector;//raycasts must originate in front of the car's hit box so it does not detect itself

        
        if (laneChange == false)
        {
            RaycastHit2D frontCast = Physics2D.Raycast(origin, directionVector, maxStoppingDistance, layerMask, 0f, 0f);
            Debug.DrawRay(origin, (directionVector * maxStoppingDistance), Color.red);

            if (frontCast.collider != null && variableSpeed > 0)
            {
                distance = (Vector2)frontCast.collider.transform.position - (Vector2)transform.position; //proximity-based deceleration, so cars have an appropriate stopping distance
                stoppingDistance = distance.magnitude - 0.1f;
                acceleration = (Mathf.Pow(speed, 2f)) / (2 * stoppingDistance);
                variableSpeed -= (acceleration * Time.deltaTime);

            }
            else if (frontCast.collider != null && variableSpeed <= 0.05)//stays  stoppped while rays detect stuff. anger points are generated when at a complete stop
            {
                variableSpeed = 0;

            }
            else if (frontCast.collider == null && variableSpeed < speed)//rays no longer detecting stuff, car accelerates
            {
                variableSpeed += 0.025f;

            }
            else//constant speed in the absence of obstructions
            {
                variableSpeed = speed;
            }



            if ((frontCast.collider != null && variableSpeed > 0) || (frontCast.collider == null && variableSpeed < speed))
            {

                offsetCastOrigin = (Vector2)transform.position - (Vector2)offsetDirection * (offset - targetOffset);

                RaycastHit2D sideCast = Physics2D.Raycast(offsetCastOrigin, directionVector, (maxStoppingDistance+1), layerMask, 0f, 0f);
                Debug.DrawRay(offsetCastOrigin, (directionVector * (maxStoppingDistance+1)), Color.red);

                RaycastHit2D sideBackCast = Physics2D.Raycast(offsetCastOrigin, (directionVector*-1), maxStoppingDistance, layerMask, 0f, 0f);
                Debug.DrawRay(offsetCastOrigin, (directionVector * maxStoppingDistance * -1), Color.red);

                if (sideCast.collider == null)
                {
                    laneChange = true;
                    //need coroutine?
                }
            }

        }

        else if(laneChange == true)
        {
            variableOffsetSpeed += 0.1f;
            variableSpeed = Mathf.Pow((4 - (Mathf.Pow(variableOffsetSpeed, 2f))), 0.5f);
            elapsedOffset += variableOffsetSpeed * Time.deltaTime;
            if(Mathf.Abs(elapsedOffset) >= Mathf.Abs(offset - targetOffset))
            {
                laneChange = false;
                offsetDirection = -1 * offsetDirection;
                variableOffsetSpeed = 0;
                
                if(targetOffset == maxOffset)
                {
                    targetOffset = minOffset;
                }
                else
                {
                    targetOffset = maxOffset;
                }

            }
        }

        transform.position = (Vector2)transform.position + directionVector * variableSpeed * Time.deltaTime + offsetDirection * variableOffsetSpeed * Time.deltaTime;

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