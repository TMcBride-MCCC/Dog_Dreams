using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FillHealth : MonoBehaviour
{
    private int currVal; 
    public int maxVal;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        currVal = maxVal;
        fill.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Testing
        if (Input.GetKeyDown(KeyCode.Z))
        {
            addToHealth(1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            subtractFromHealth(1);
        }
    }

    public void addToHealth(int i)
    {
        currVal += i;

        if (currVal > maxVal)
        {
            currVal = maxVal;
        }

        fill.fillAmount = (float) currVal / maxVal;
    }

    public void subtractFromHealth(int i)
    {
        currVal -= i;

        if (currVal < 0)
        {
            currVal = 0;
        }

        fill.fillAmount = (float)currVal / maxVal;
    }
}
