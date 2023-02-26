using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Hearts : MonoBehaviour
{
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;

    float playerHearts = PlayerController.playerHealth;

    // Update is called once per frame
    void Update()
    {
        if(playerHearts == 2)
        {
            Destroy(Heart3);
        }
        else if(playerHearts == 1)
        {
            Destroy(Heart2);
        }
        else if(playerHearts == 0)
        {
            Destroy(Heart1);
        }
    }
}
