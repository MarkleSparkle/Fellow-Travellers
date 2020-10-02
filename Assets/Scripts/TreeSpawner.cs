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
        float horizontalMin = -halfWidth - 1.2f;
        float horizontalMax = -halfWidth - 1.2f;
        float verticalMin = halfHeight - 1.2f;
        float verticalMax = halfHeight + 1.2f;


        for(int i = 0; i < 100; i++)
        {
            position = new Vector3(Random.Range(horizontalMin, horizontalMax),Random.Range(verticalMin,verticalMax),-1);
            Instantiate(treeFab, position, Quaternion.identity);
        }
    }
}
