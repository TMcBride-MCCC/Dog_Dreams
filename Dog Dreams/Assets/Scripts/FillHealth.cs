using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FillHealth : MonoBehaviour
{
    private int currHP; 
    private int maxHP;
    private PlayerController playerController;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        //Get the PlayerController
        playerController = FindAnyObjectByType<PlayerController>();
        //Set values
        currHP = playerController.health;
        maxHP = playerController.maxHealth;
        //Controll the fill on UI
        fill.fillAmount = (float)currHP / maxHP;
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

        //Check values
        currHP = playerController.health;
        maxHP = playerController.maxHealth;
        //Control the fill on UI
        fill.fillAmount = (float)currHP / maxHP;
    }

    public void addToHealth(int i)
    {
        currHP += i;

        if (currHP > maxHP)
        {
            currHP = maxHP;
        }

        playerController.health = currHP;
        fill.fillAmount = (float) currHP / maxHP;
    }

    public void subtractFromHealth(int i)
    {
        currHP -= i;

        if (currHP < 0)
        {
            currHP = 0;
        }

        playerController.health = currHP;
        fill.fillAmount = (float)currHP / maxHP;
    }
}
