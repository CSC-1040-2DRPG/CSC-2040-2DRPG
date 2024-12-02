using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_mana : MonoBehaviour, IDataPersistence
{

    public Slider manaSlider;
    public float maxMana = 100f;
    public float mana;
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        mana = maxMana;
        manaSlider.maxValue = maxMana;
        manaSlider.value = mana;
    }

    public void UseMana(float ManaCost)
    {
        audioManager.PlaySFX(audioManager.boomsound);
        mana = Mathf.Max(mana - ManaCost, 0);
        manaSlider.value = mana;
    }

    public void RecoverMana(float Recover)
    {
        mana = mana + Recover;
    }

    public void Update()
    {

        
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
