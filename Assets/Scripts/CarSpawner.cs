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

    private float colliderScale = 1;
    
    //Fellow Travellers
    public GameObject blueFT;
    public GameObject blackFT;
    public GameObject yellowFT;
    public GameObject whiteFT;
    public GameObject fusiaFT;
    public GameObject orangeFT;
    public GameObject greenFT;

    //Trucks
    public GameObject blueTruck;
    public GameObject blackTruck;
    public GameObject yellowTruck;
    public GameObject whiteTruck;
    public GameObject redTruck;
    public GameObject orangeTruck;
    public GameObject greenTruck;

    //Cop Cars
    public GameObject blackCopCar;

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
        float horizontalMin = -halfWidth - 2.4f;
        float horizontalMax = halfWidth + 2.4f;
        float verticalMin = -halfHeight - 2.4f;
        float verticalMax = halfHeight + 2.4f;
        Vector2 direction;

        //creates a new car after a certain amount of time
        if (currentTime > maxTime)
        {
            GameObject newCar;
            float randomCharacter = Random.Range(0, 6);//random character type(car, truck)
            float randomCar = Random.Range(0, 7);//random colour

            float randomOffset = Random.Range(0, 2);
            float offset = 0; //lane designation for cars

            switch (randomOffset)//cars are randomly assigned to a lane (since we for whatever reason decided on double lanes)
            {
                case 0:
                    offset = 0.5f;
                    break;
                case 1:
                    offset = 1.5f;
                    break;
            }

            if (randomCharacter >= 0 && randomCharacter <= 2)//select from Fellow Traveller list
            {
                colliderScale = 1;

                switch (randomCar)
                {
                    case 0:
                        newCar = Instantiate(fusiaFT);
                        break;

                    case 1:
                        newCar = Instantiate(blueFT);
                        break;

                    case 2:
                        newCar = Instantiate(greenFT);
                        break;

                    case 3:
                        newCar = Instantiate(orangeFT);
                        break;

                    case 4:
                        newCar = Instantiate(blackFT);
                        break;

                    case 5:
                        newCar = Instantiate(whiteFT);
                        break;

                    case 6:
                        newCar = Instantiate(yellowFT);
                        break;

                    default:
                        newCar = Instantiate(blueFT);
                        break;
                }

            }

            else if (randomCharacter == 4 || randomCharacter == 5)//select from truck list
            {
                colliderScale = 1.2f;//the trucks are slightly larger

                switch (randomCar)
                {
                    case 0:
                        newCar = Instantiate(redTruck);
                        break;

                    case 1:
                        newCar = Instantiate(blueTruck);
                        break;

                    case 2:
                        newCar = Instantiate(greenTruck);
                        break;

                    case 3:
                        newCar = Instantiate(orangeTruck);
                        break;

                    case 4:
                        newCar = Instantiate(blackTruck);
                        break;

                    case 5:
                        newCar = Instantiate(whiteTruck);
                        break;

                    case 6:
                        newCar = Instantiate(yellowTruck);
                        break;

                    default:
                        newCar = Instantiate(blueTruck);
                        break;
                }
            }
            else
            {
                colliderScale = 0.8f;
                newCar = Instantiate(blackCopCar);
                
            }

            carBox = newCar.AddComponent<BoxCollider2D>() as BoxCollider2D;
            carBox.isTrigger = true;
            carBox.size = new Vector2(colliderScale, colliderScale);

            

            //choose position
            float randomDirection = Random.Range(0,4);
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
                    offsetDirection = Vector2.down; 
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
