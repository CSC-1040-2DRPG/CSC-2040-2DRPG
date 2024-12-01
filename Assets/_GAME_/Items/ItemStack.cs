using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;



[Serializable]
public class ItemStack
{
    public enum ItemType {
        Sword, //0
        Pickaxe, //1
        HealthPotion, //2
        ManaPotion,
        Staff,
        Key
    }

    [SerializeField] public ItemType itemType;
    [SerializeField] public int stackAmount;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public ItemStack(ItemType itemType, int stackAmount, AudioManager audioManager) {
        this.itemType = itemType;
        this.stackAmount = stackAmount;
        this.audioManager = audioManager;
    }

    public ItemStack(ItemType itemType, AudioManager audioManager) : this(itemType, 1, audioManager){}

    public void SetAudioManager(AudioManager manager)
    {
        audioManager = manager;
    }

    public void useItem() {
        if (audioManager == null) {
            audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
        }
        if (stackAmount < 1) return;
        switch (itemType) {
            case ItemType.Sword:
                playerDataHandler.instance.GetComponentInChildren<Sword>().Attack();
                int randomSwordSound = UnityEngine.Random.Range(0, 2);
                AudioClip[] swordSounds = {audioManager.swordsound1, audioManager.swordsound2, audioManager.swordsound3};
                audioManager.PlaySFX(swordSounds[randomSwordSound]);
                break;

            case ItemType.HealthPotion:
                //check if 
                if (playerDataHandler.instance.GetComponentInChildren<Player_health>().health >= playerDataHandler.instance.GetComponentInChildren<Player_health>().maxHealth) break;
                playerDataHandler.instance.GetComponentInChildren<Player_health>().HealHealth(10);
                stackAmount--;
                audioManager.PlaySFX(audioManager.potionsound);
                break;

            case ItemType.ManaPotion:
                if (playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana >= playerDataHandler.instance.GetComponentInChildren<Player_mana>().maxMana) break;
                playerDataHandler.instance.GetComponentInChildren<Player_mana>().RecoverMana(10);
                stackAmount--;
                audioManager.PlaySFX(audioManager.potionsound);
                break;

            case ItemType.Pickaxe:
                playerDataHandler.instance.GetComponentInChildren<Pickaxe>().Swing();
                break;
            }
            Debug.Log(itemType + " used! " + stackAmount + " remaining.");
        }

        public String getName() {
            return itemType.ToString();
        }
        public String getFormattedName() {
            return Regex.Replace(itemType.ToString(), "(?<!^)([A-Z])", " $1").Trim();
        }
    }