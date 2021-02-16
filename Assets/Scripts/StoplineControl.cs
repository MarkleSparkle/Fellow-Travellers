using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplineControl : MonoBehaviour
{//This script will be used to manage light and traffic direction toggle
    public GameObject leftLine;
    public GameObject rightLine;
    public GameObject topLine;
    public GameObject bottomLine;

    public GameObject stopLine;
    public BoxCollider2D leftBox;
    public BoxCollider2D rightBox;
    public BoxCollider2D topBox;
    public BoxCollider2D bottomBox;

    public GameObject TopRedGlow;
    public GameObject TopAmberGlow;
    public GameObject TopGreenGlow;

    public GameObject LeftRedGlow;
    public GameObject LeftAmberGlow;
    public GameObject LeftGreenGlow;

    public GameObject BottomRedGlow;
    public GameObject BottomAmberGlow;
    public GameObject BottomGreenGlow;

    public GameObject RightRedGlow;
    public GameObject RightAmberGlow;
    public GameObject RightGreenGlow;

    public string DirectionOfTraffic;

    // Start is called before the first frame update
    void Start()//right and left will have enabled colliders by default
    {
        /*GameObject leftLine = Instantiate(stopLine);//Create left stopline
        leftLine.transform.Rotate(0, 0, 90);
        leftLine.transform.position = new Vector3(-2.4f, -1, 0.1f);//approximated.  lines also need to be between the background and the cars on the Z axis
        leftLine.transform.localScale = new Vector2(2, 2);*/
        leftBox = leftLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        leftBox.isTrigger = true;

        /*GameObject rightLine = Instantiate(stopLine);//right side stopline
        rightLine.transform.Rotate(0, 0, 90);
        rightLine.transform.position = new Vector3(2.2f, 1, 0.1f);
        rightLine.transform.localScale = new Vector2(2, 2);*/
        rightBox = rightLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        rightBox.isTrigger = true;


        /*GameObject topLine = Instantiate(stopLine);//top line doesn't need rotation
        topLine.transform.position = new Vector3(-1.1f, 2.2f, 0.1f);
        topLine.transform.localScale = new Vector2(2, 2);*/
        topBox = topLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        topBox.isTrigger = true;
        topBox.enabled = false;

       /* GameObject bottomLine = Instantiate(stopLine);//hahaha I'm totally losing it
        bottomLine.transform.position = new Vector3(0.9f, -2.2f, 0.1f);
        bottomLine.transform.localScale = new Vector2(2, 2);*/
        bottomBox = bottomLine.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bottomBox.isTrigger = true;
        bottomBox.enabled = false;

        DirectionOfTraffic = "UpDown";

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            //if direction of traffic is not already in this direction
            if (DirectionOfTraffic != "LeftRight")
            {
                //starts a co-routine that has the ability to wait (creates smooth animation for traffic light)
                //https://stackoverflow.com/questions/55246755/how-to-achieve-thread-sleep-functionality-in-unity-script
                StartCoroutine(EnableLeftRight());
                DirectionOfTraffic = "LeftRight";
            }
        }

        if (Input.GetKeyDown("up") || Input.GetKeyDown("down"))
        {
            if (DirectionOfTraffic != "UpDown")
            {
                StartCoroutine(EnableTopBottom());
                DirectionOfTraffic = "UpDown";
            }
        }
    }

    private IEnumerator EnableLeftRight()
    {

        //enable all stop lines
        leftBox.enabled = true;
        rightBox.enabled = true;
        topBox.enabled = true;
        bottomBox.enabled = true;
        Debug.Log("Enabling all stop boxes");

        //setting top/bottom amber glow active
        TopRedGlow.SetActive(false);
        TopAmberGlow.SetActive(true);
        TopGreenGlow.SetActive(false);

        BottomRedGlow.SetActive(false);
        BottomAmberGlow.SetActive(true);
        BottomGreenGlow.SetActive(false);

        //wait
        yield return new WaitForSeconds(1.5f);

        //setting top/bottom red glow active
        TopRedGlow.SetActive(true);
        TopAmberGlow.SetActive(false);
        TopGreenGlow.SetActive(false);

        BottomRedGlow.SetActive(true);
        BottomAmberGlow.SetActive(false);
        BottomGreenGlow.SetActive(false);

        //wait
        yield return new WaitForSeconds(1.5f);

        //disable east/west boxes
        leftBox.enabled = false;
        rightBox.enabled = false;
        Debug.Log("Disabling left/right stop boxes");

        //setting left/right green glow active
        LeftRedGlow.SetActive(false);
        LeftAmberGlow.SetActive(false);
        LeftGreenGlow.SetActive(true);

        RightRedGlow.SetActive(false);
        RightAmberGlow.SetActive(false);
        RightGreenGlow.SetActive(true);
    }

    private IEnumerator EnableTopBottom()
    {
        //enable all stop lines
        leftBox.enabled = true;
        rightBox.enabled = true;
        topBox.enabled = true;
        bottomBox.enabled = true;
        Debug.Log("Enabling all stop boxes");

        //setting left/right amber glow active
        LeftRedGlow.SetActive(false);
        LeftAmberGlow.SetActive(true);
        LeftGreenGlow.SetActive(false);

        RightRedGlow.SetActive(false);
        RightAmberGlow.SetActive(true);
        RightGreenGlow.SetActive(false);

        //wait
        yield return new WaitForSeconds(1.5f);

        //setting left/right red glow active
        LeftRedGlow.SetActive(true);
        LeftAmberGlow.SetActive(false);
        LeftGreenGlow.SetActive(false);

        RightRedGlow.SetActive(true);
        RightAmberGlow.SetActive(false);
        RightGreenGlow.SetActive(false);

        //wait
        yield return new WaitForSeconds(1.5f);

        //altering the stop lights
        topBox.enabled = false;
        bottomBox.enabled = false;
        Debug.Log("Disabling top/bottom stop boxes");

        //setting top/bottom green glow active
        TopRedGlow.SetActive(false);
        TopAmberGlow.SetActive(false);
        TopGreenGlow.SetActive(true);

        BottomRedGlow.SetActive(false);
        BottomAmberGlow.SetActive(false);
        BottomGreenGlow.SetActive(true);

    }


}
