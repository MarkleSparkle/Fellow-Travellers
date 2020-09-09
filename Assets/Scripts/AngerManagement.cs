using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private float angerPoints = 0;
    public Text angerText;
    
    void start()
    {
        angerText.text = "Anger: 0";
    }

    public void updateAngerPoints(float angerInput)
    {
        angerPoints += angerInput;
        angerText.text = "Anger: " + angerPoints.ToString();
    }
}