using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_mana : MonoBehaviour
{
    
    
 

    public Slider manaSlider;
    public float maxMana = 100f;
    public float mana;

    void Start()
    {
        mana = maxMana;
        manaSlider.maxValue = maxMana;
        manaSlider.value = mana;
    }

    public void UseManaDamage(float ManaCost)
    {
        mana = Mathf.Max(mana - ManaCost, 0);
        manaSlider.value = mana;
    }

    
}
