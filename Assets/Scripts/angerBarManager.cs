using System;
using UnityEngine;
using UnityEngine.UI;

public class angerBarManager : MonoBehaviour
{
    public Slider angerSlider;
    public Gradient angerGradient;
    public Image angerFill;
    public Text rageCounter;
    public GameObject star1;
    public GameObject star1Holo;
    public GameObject star2;
    public GameObject star2Holo;
    public GameObject star3;
    public GameObject star3Holo;

    //score popup prefab
    public GameObject PopupText;

    private bool star1active;
    private bool star2active;
    private bool star3active;
    private float lastRage;
    private float rageFloat;
    

    private void Start()
    {
        rageFloat = 0;
        star1active = true;
        star2active = true;
        star3active = true;
    }

    public bool[] areStarsActive()
    {
        bool[] active = new bool[3];
        active[0] = star1active;
        active[1] = star2active;
        active[2] = star3active;
        return active;
    }

    public void addAnger(float angerPoints)
    {
        if (Time.timeScale > 0f) //if the game is not paused
        {
            angerSlider.value -= angerPoints;
            angerFill.color = angerGradient.Evaluate(angerSlider.normalizedValue);
            rageFloat += angerPoints;
            rageCounter.text = Mathf.Floor(rageFloat).ToString();
        }

        if (angerSlider.value <= 613 && star3active)
        {
            star3.SetActive(false);
            star3active = false;
        }
        if (angerSlider.value <= 333 && star2active)
        {
            star2.SetActive(false);
            star2active = false;
        }
        if (angerSlider.value <= 0 && star1active)
        {
            star1.SetActive(false);
            star1active = false;
        }

    }

    public float getAnger()
    {
        return angerSlider.value;
    }

    
}
