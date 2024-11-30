using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public int currentMoney = 0;


    // called when the script is first loaded, or when an object it is attached to is instantiated
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        //Debug.log("Money added: " + amount + ". Current Money: " + currentMoney);
    }

   
}
