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
    public GameObject fellowTraveller;
    public BoxCollider2D carBox;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 2;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        float horizontalMin = -halfWidth - 1.2f;
        float horizontalMax = halfWidth + 1.2f;
        float verticalMin = -halfHeight - 1.2f;
        float verticalMax = halfHeight + 1.2f;
        Vector2 direction;

        //creates a new car after a certain amount of time
        if (currentTime > maxTime)//control of car despawn sequence has been moved to the individual move scripts.  in essence, cars now self destruct
        {//we will create a new column object
            GameObject newCar = Instantiate(fellowTraveller);
            carBox = newCar.AddComponent<BoxCollider2D>() as BoxCollider2D;
            carBox.isTrigger = true;

            float randomOffset = Mathf.Round(Random.value);
            float offset = 0; //lane designation for cars

            switch (randomOffset)//cars are randomly assigned to a lane (since we for whatever reason decided on double lanes)
            {
                case 0:
                    offset = 0.6f;
                    break;
                case 1:
                    offset = 1.5f;
                    break;
            }

            //choose position
            float randomDirection = Mathf.Round(Random.value * 3);
            //Debug.Log("Generated Direction: " + randomDirection);

            Vector2 startingPoint = new Vector2();
            Vector2 offsetDirection;// lane offsets (i.e. cars coming from the right are offset upwards, into the "right lane")
            float changePoint;
            switch (randomDirection)//starting from the...
            {

                case 0://...left

                    //starting point
                    startingPoint.x = horizontalMin;
                    changePoint = horizontalMin;
                    direction = Vector2.right;
                    offsetDirection = Vector2.down; //These will make the cars spawn in the correct lane, so they won't collide headlong
                    //rotation
                    newCar.transform.Rotate(0,0,270);

                    break;
                case 1:
                    //...top

                    //starting point
                    startingPoint.y = verticalMax;
                    changePoint = verticalMax;
                    direction = Vector2.up;
                    offsetDirection = Vector2.left;

                    //rotation
                    newCar.transform.Rotate(0, 0, 180);

                    break;
                case 2://...right

                    startingPoint.x = horizontalMax;
                    changePoint = horizontalMax;
                    direction = Vector2.right;
                    offsetDirection = Vector2.up;
                    //set rotation
                    newCar.transform.Rotate(0, 0, 90);

                    break;

                case 3://...bottom

                    startingPoint.y = verticalMin;
                    changePoint = verticalMin;
                    direction = Vector2.up;
                    offsetDirection = Vector2.right;

                   

                    break;
                default://just in case there are decimals
                    //Debug.Log("ERROR: " + randomDirection);

                    //starting point is (0,0)
                    changePoint = verticalMin;
                    direction = Vector2.up;
                    offsetDirection = Vector2.right;

                    newCar.transform.Rotate(0,0,270);

                    break;
            }


            //trying to pass the direction of the car to the move script
            //Move script = newCar.GetComponent<Move>;


            //setting new car's main position
            newCar.transform.position = (Vector2) transform.position +
            direction * changePoint + (Vector2) transform.position + offsetDirection * offset;

            //Destroy(newCar, 15f);


            currentTime = 0;//resetting the current time after spawning a car
        }

        currentTime += Time.deltaTime;
        //adding the time between frames to the current time
    }
}
