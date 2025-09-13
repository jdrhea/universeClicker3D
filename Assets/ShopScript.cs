using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public TMP_Text kmText;
    public Text itemCostText;
    public TMP_Text itemNameText;
    public Image CantAfford;
    private int costumeINDEX = 0; // Index for the current costume
    public List<int> ItemCosts = new List<int>();
    public List<string> ItemNames = new List<string>();
    public static int clickValue = 1;
    public static int Temperature = 30;
    public TMP_Text tempText;
    bool inflate = false;


    // purchase buttons
    private IEnumerator HideCantAfford()
    {
        yield return new WaitForSeconds(2f);
        CantAfford.gameObject.SetActive(false);
    }
    void Start()
    {
        itemCostText.text = "BUY:" + ItemCosts[costumeINDEX] + "km";
        itemNameText.text = ItemNames[costumeINDEX];
    }
    void Update()
    {
        if (inflate)
        {
            CosmicExpansion();
        }
    }
    public void BuyItem()
    {
        int item = ItemCosts[costumeINDEX];

        if (Click.km >= item)
        {
            Click.km -= item;
            if (costumeINDEX == 0)
            {
                clickValue = 2;
            }
            if (costumeINDEX == 1)
            {

            }
            if (costumeINDEX == 2)
            {
                inflate = true;
            }
            if (costumeINDEX == 3)
            {
                Temperature /= 2;
                SetTemp();
            }
            if (costumeINDEX == 4)
            {
                clickValue = 4;
                SetTemp();
            }

        }
        else
        {
            CantAfford.gameObject.SetActive(true);
            StartCoroutine(HideCantAfford());
        }
    }
    public void Next()
    {
        if (costumeINDEX >= ItemCosts.Count - 1)
        {
            costumeINDEX = 0; // Loop back to the first item
        }
        else
        {
            costumeINDEX++;
        }
        SetScore();
    }
    public void Previous()
    {
        if (costumeINDEX == 0)
        {
            costumeINDEX = ItemCosts.Count - 1; // Loop to the last item
        }
        else
        {
            costumeINDEX--;
        }
        SetScore();
    }
    private void CosmicExpansion()
    {
        float inflation = 1 / 1000f;
        float expansion = ((((Time.time * Time.time) * inflation) - (0 * Time.time)) + 0) * Time.deltaTime;
        Click.km += expansion;
        SetScore();
    }

    public void SetScore()
    {
        kmText.text = Click.km + "km";
        itemCostText.text = "BUY: " + ItemCosts[costumeINDEX] + "km";
        itemNameText.text = ItemNames[costumeINDEX];
    }
    public void SetTemp()
    {
        tempText.text = "Temperature: 10^" + Temperature + " K";
    }

}
