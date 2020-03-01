using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float speed;
    public Vector2 originalDirection;
    private Vector2 directionVector;


    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;

        float direction = transform.rotation.z;
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

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)transform.position + directionVector * speed * Time.deltaTime;

    }
}
