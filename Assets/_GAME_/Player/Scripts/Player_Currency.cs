using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Currency : MonoBehaviour
{

public int currency = 0;



    // Start is called before the first frame update
    void Start()
    {



    }


public int getCurrency(){
    return currency;
}

public void addCurrency(int amount){
    currency = amount + currency;
}

public void subCurrency(int amount){
    currency = currency - amount;
}


}
