using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click : MonoBehaviour
{
    public TMP_Text kmText;
    public TMP_Text ageText;
    public static float km = 0;
    public float age = 0;
    public List<string> unitsOfTime = new List<string> { "seconds", "minutes", "hours", "days", "years" };

    void OnMouseDown()
    {
        km+= ShopScript.clickValue; // Increment km by the click value from ShopScript
    }
    void Update()
    {
        kmText.text = Mathf.RoundToInt(km) + " km";

        transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);

        age += 1 * Time.deltaTime;

        int displayValue = Mathf.RoundToInt(age);
        string unit = unitsOfTime[0]; // "seconds"
        
        if (age >= 60 && age < 3600)
        {
            displayValue = Mathf.RoundToInt(age / 60);
            unit = unitsOfTime[1]; // "minutes"
        }
        else if (age >= 3600 && age < 86400)
        {
            displayValue = Mathf.RoundToInt(age / 3600);
            unit = unitsOfTime[2]; // "hours"
        }
        else if (age >= 86400 && age < 31536000)
        {
            displayValue = Mathf.RoundToInt(age / 86400);
            unit = unitsOfTime[3]; // "days"
        }
        else if (age >= 31536000)
        {
            displayValue = Mathf.RoundToInt(age / 31536000);
            unit = unitsOfTime[4]; // "years"
        }
        ageText.text = displayValue + " " + unit;

    }
}
