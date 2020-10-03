using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{//TreeSpawner spawns trees in the corners of the map at the beginning of the game

    public GameObject treeFab; //see what I did there? ;D

    void Start()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        Vector3 position;

        /* Spawning the Top Left*/

        //defining boundary coordinates
        float horizontalMin = halfWidth + 1.2f;
        float horizontalMax = 2.2f;

        float verticalMin = 2.5f;
        float verticalMax = halfHeight + 0.4f;


        for(int i = 0; i < 150; i++)
        {
            switch (Random.Range(0 , 4))
            {
                case 0://spawning tree in top left
                    position = new Vector3(Random.Range(-horizontalMin, -horizontalMax), Random.Range(verticalMin, verticalMax), -1);
                    break;

                case 1://spawning tree in top right
                    position = new Vector3(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax), -1);
                    break;

                case 2://spawning tree in bottom right
                    position = new Vector3(Random.Range(horizontalMin, horizontalMax), Random.Range(-verticalMin, -verticalMax), -1);
                    break;

                case 3://spawning tree in bottom left
                    position = new Vector3(Random.Range(-horizontalMin, -horizontalMax), Random.Range(-verticalMin, -verticalMax), -1);
                    break;

                default:
                    position = new Vector3(0,0,1);
                    break;
            }
            Instantiate(treeFab, position, Quaternion.identity);//TODO - use Euler's Angles (not Quaternion) to create random rotation.
        }
    }
}
