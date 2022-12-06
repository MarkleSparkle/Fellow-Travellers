using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    AudioSource exhaustSound;
    bool up;
    bool down;
    float topPitch = 1.7f;
    float bottomPitch= 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        up = false;
        down = false;
        exhaustSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up) //if playing pitch up noise
        {
            if (exhaustSound.pitch <= topPitch) //if the exhaust pitch is not all the way up
                exhaustSound.pitch += 0.01f;
            else
            {
                exhaustSound.Stop();
                up = false;
            }
        }
        else if (down) //if playing pitch down noise
        {
            if (exhaustSound.pitch >= bottomPitch) //if the exhaust pitch is not all the way up
                exhaustSound.pitch -= 0.01f;
            else
            {
                exhaustSound.Stop();
                down = false;
            }
        }
    }

    public void pitchUp()
    {
        up = true;
        exhaustSound.Play();
    }
    public void pitchDown()
    {
        down = true;
        exhaustSound.Play();
    }
}
