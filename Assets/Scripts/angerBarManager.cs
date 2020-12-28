using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class angerBarManager : MonoBehaviour
{
    public Slider angerSlider;
    public Gradient angerGradient;
    public Image angerFill;

    public void addAnger(float angerPoints)
    {
        angerSlider.value += angerPoints;
        angerFill.color = angerGradient.Evaluate(angerSlider.normalizedValue);
    }
}
