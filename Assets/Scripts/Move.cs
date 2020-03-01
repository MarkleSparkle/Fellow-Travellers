using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float speed;
    public Vector2 originalDirection;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        float direction = transform.rotation.z;
        switch (direction) {
            case 0:
                transform.position = (Vector2)transform.position + Vector2.left * speed * Time.deltaTime;
                break;

            case 90:
                transform.position = (Vector2)transform.position + Vector2.down * speed * Time.deltaTime;
                break;

            case 180:
                transform.position = (Vector2)transform.position + Vector2.right * speed * Time.deltaTime;
                break;

            case 270:
                transform.position = (Vector2)transform.position + Vector2.up * speed * Time.deltaTime;
                break;

        }

    }
}
