using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ILastTouched : MonoBehaviour
{

    public Collider iLastEntered;
    public Collider iLastExited;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        iLastEntered = col;

    }

    void OnTriggerExit(Collider col)
    {
        iLastExited = col;


    }
}