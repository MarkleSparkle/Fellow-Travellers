using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourDifferentCol : MonoBehaviour
{

    private enum enemyBehaviour {none, agro, attack, retreat }

    private enemyBehaviour currentBehaviour = 0;

    private Collider myColLastHit, myColLastExited;

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



        //this need to happen after the other object registers what it touched
        //so maybe a coroutine would help
        //as it is it will always report the last thing it triggered not the current

        //rather than a coroutine the object colliding could be the one making the decisions
        //it could have the trigger and it could tell what it collides with what to do
        //e.g. if col.tag is enemy, then getComponent<enemyScript>()
        //then tell the script to run its behaviour method which could be
        // myBehaviour(Collider){} it receives a collider type and behaves differently
        //depending which collider, it is given, or a string with the colliders name could be 
        //given


        myColLastHit = col.gameObject.GetComponent<ILastTouched>().iLastEntered;


        if (myColLastHit is SphereCollider) { currentBehaviour = enemyBehaviour.attack; }
        else if (myColLastHit is BoxCollider) { currentBehaviour = enemyBehaviour.retreat; }
        else if (myColLastHit is CapsuleCollider) { currentBehaviour = enemyBehaviour.agro; }


        Debug.Log(currentBehaviour);

    }

    void OnTriggerExit(Collider col)
    {



        myColLastExited = col.gameObject.GetComponent<ILastTouched>().iLastExited;



        if (myColLastExited is CapsuleCollider) { currentBehaviour = enemyBehaviour.none; }
        if (myColLastExited is SphereCollider) { currentBehaviour = enemyBehaviour.agro; }
        else if (myColLastExited is BoxCollider) { currentBehaviour = enemyBehaviour.attack; }




        Debug.Log(currentBehaviour);

    }


}