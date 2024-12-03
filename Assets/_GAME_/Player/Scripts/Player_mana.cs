using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_mana : MonoBehaviour, IDataPersistence
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

    public void UseMana(float ManaCost)
    {
        mana = Mathf.Max(mana - ManaCost, 0);
        manaSlider.value = mana;
    }

    public void RecoverMana(float Recover)
    {
        mana = mana + Recover;
    }

    public void Update()
    {

        //recover mana gradully 
        if (manaSlider.value < 100)
        {
            mana += 0.004f;
        }
        
        if (manaSlider.value != mana)
       {
            manaSlider.value = mana;
           
        }
    }

    public void LoadData(GameData data){
        mana = data.playerMana;
    }

    public void SaveData(GameData data){
        data.playerMana = mana;
    }

}
