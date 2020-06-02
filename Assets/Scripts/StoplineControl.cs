using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplineControl : MonoBehaviour
{//This script will be used to instantiate stoplines and allow the user to toggle their rigid bodies.  Stoplight animations to be addded later...
    public GameObject stopLine;
    public BoxCollider2D leftBox;
    public BoxCollider2D rightBox;
    public BoxCollider2D topBox;
    public BoxCollider2D bottomBox;
    // Start is called before the first frame update
    void Start()//start will create four instantiations of the stop line prefab. right and left will have enabled colliders by default
    {
        GameObject leftLine = Instantiate(stopLine);//Create left stopline
        leftLine.transform.Rotate(0, 0, 90);
        leftLine.transform.position = new Vector3(-1.8f, -1, 0.1f);//approximated.  lines also need to be between the background and the cars on the Z axis
        leftLine.transform.localScale = new Vector2(2, 2);//original prefab will be upscaled by a factor of 2. you made it too small, mark
        leftBox = leftLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        leftBox.isTrigger = true;

        GameObject rightLine = Instantiate(stopLine);//right side stopline
        rightLine.transform.Rotate(0, 0, 90);
        rightLine.transform.position = new Vector3(2.8f, 1, 0.1f);
        rightLine.transform.localScale = new Vector2(2, 2);
        rightBox = rightLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        rightBox.isTrigger = true;


        GameObject topLine = Instantiate(stopLine);//top line doesn't need rotation
        topLine.transform.position = new Vector3(-0.5f, 2.2f, 0.1f);
        topLine.transform.localScale = new Vector2(2, 2);
        topBox = topLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        topBox.isTrigger = true;
        topBox.enabled = false;

        GameObject bottomLine = Instantiate(stopLine);//hahaha I'm totally losing it
        bottomLine.transform.position = new Vector3(1.5f, -2.2f, 0.1f);
        bottomLine.transform.localScale = new Vector2(2, 2);
        bottomBox = bottomLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bottomBox.isTrigger = true;
        bottomBox.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            leftBox.enabled = false;
            rightBox.enabled = false;
            topBox.enabled = true;
            bottomBox.enabled = true;
            Debug.Log("Right/Left enabled");
        }

        if(Input.GetKeyDown("up") || Input.GetKeyDown("down"))
        {
            leftBox.enabled = true;
            rightBox.enabled = true;
            topBox.enabled = false;
            bottomBox.enabled = false;
            Debug.Log("Up/Down Enabled");
        }
    }
}
