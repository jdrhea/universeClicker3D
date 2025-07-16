using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click : MonoBehaviour
{
    public TMP_Text clicks;
    public int clickCount = 0;

    void OnMouseDown()
    {
        clickCount++;
        clicks.text = clickCount + "km";
    }
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);
    }
}
