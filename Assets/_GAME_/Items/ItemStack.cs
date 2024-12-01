using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;



[Serializable]
public class ItemStack
{
    public enum ItemType {
        Sword, //0
        Pickaxe, //1
        HealthPotion, //2
        ManaPotion,
        Bow,
        Key
    }

    [SerializeField] public ItemType itemType;
    [SerializeField] public int stackAmount;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public ItemStack(ItemType itemType, int stackAmount, AudioManager audioManager){
        this.itemType = itemType;
        this.stackAmount = stackAmount;
        this.audioManager = audioManager;
    }

    public ItemStack(ItemType itemType){
        this.itemType = itemType;
        this.stackAmount = 1;
    }

    public void SetAudioManager(AudioManager manager)
    {
        audioManager = manager;
    }

    public void useItem(){
        if (audioManager == null){
            audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
        }
            if (stackAmount < 1) return;
        switch(itemType){
            case ItemType.Sword:
                playerDataHandler.instance.GetComponentInChildren<Weapon_parent>().Attack();
                //play sound effect
                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.swordswoosh);
                }
                else
                {
                    Debug.LogError("AudioManager is not assigned!");
                }
                break;
            //use health potion
            case ItemType.HealthPotion:
                //check if 
                if(playerDataHandler.instance.GetComponentInChildren<Player_health>().health >= playerDataHandler.instance.GetComponentInChildren<Player_health>().maxHealth) break;
                playerDataHandler.instance.GetComponentInChildren<Player_health>().HealHealth(10);
                stackAmount--;
                break;

            case ItemType.ManaPotion:
                if(playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana >= playerDataHandler.instance.GetComponentInChildren<Player_mana>().maxMana) break;
                playerDataHandler.instance.GetComponentInChildren<Player_mana>().RecoverMana(10);
                stackAmount--;
                break;
        }
        Debug.Log(itemType + " used! " + stackAmount + " remaining.");
    }

    public String getName(){
        return itemType.ToString();
    }
    public String getFormattedName(){
        return Regex.Replace(itemType.ToString(), "(?<!^)([A-Z])", " $1").Trim();
    }
}
