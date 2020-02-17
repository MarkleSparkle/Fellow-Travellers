using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    /**
     * This script spawns cars off screen and 
     * removes them once they reach their destination (off-screen).
     */

    private float maxTime;
    private float currentTime;
    public GameObject uglyCar;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 5;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //creates a new car after a certain amount of time
        if (currentTime > maxTime)
        {//we will create a new column object
            GameObject newCar = Instantiate(uglyCar);

            //getting the camera dimensions
            Camera camera = Camera.main;
            float halfHeight = camera.orthographicSize;
            float halfWidth = camera.aspect * halfHeight;

            float horizontalMin = -halfWidth;
            float horizontalMax = halfWidth;
            float verticalMin = -halfHeight;
            float verticalMax = halfHeight;


            //choose position
            float randomDirection = Mathf.Round(Random.value * 3);
            Debug.Log("" + randomDirection);

            Vector2 direction;
            Vector2 startingPoint = new Vector2();
            float changePoint;
            switch (randomDirection)//starting from the...
            {

                case 0:
                    //...left
                    Debug.Log("LEFT" + randomDirection);

                    //starting point
                    startingPoint.x = horizontalMin;
                    changePoint = horizontalMin;
                    direction = Vector2.right;

                    break;
                case 1:
                    //...top
                    Debug.Log("TOP" + randomDirection);

                    //starting point
                    startingPoint.y = verticalMax;
                    changePoint = verticalMax;
                    direction = Vector2.up;

                    break;
                case 2:
                    //...right
                    Debug.Log("RIGHT" + randomDirection);

                    startingPoint.x = horizontalMax;
                    changePoint = horizontalMax;
                    direction = Vector2.right;

                    break;
                case 3:
                    //...bottom
                    Debug.Log("BOTTOM" + randomDirection);

                    startingPoint.y = verticalMin;
                    changePoint = verticalMin;
                    direction = Vector2.up;

                    break;
                default:
                    //just in case there are decimals
                    Debug.Log("DEFAULT: " + randomDirection);

                    //starting point is (0,0)
                    changePoint = 0;
                    direction = Vector2.up;

                    break;
            }


            //trying to pass the direction of the car to the move script
            //Move script = newCar.GetComponent<Move>;


            //setting new car's position
            newCar.transform.position = (Vector2) transform.position +
            direction * changePoint;


            Destroy(newCar, 15f);
            currentTime = 0;//resetting the current time after spawning a car
        }

        currentTime += Time.deltaTime;
        //adding the time between frames to the current time
    }
}
