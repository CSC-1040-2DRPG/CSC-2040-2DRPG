using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;



[Serializable]
public class ItemStack
{
    [Serializable]
    public enum ItemType
    {
        None, //0
        Sword, //1
        Pickaxe,
        HealthPotion,
        ManaPotion,
        Staff,
        Key
    }

    [SerializeField] public ItemType itemType;
    [SerializeField] public int stackAmount;
    public ItemStack(ItemType itemType, int stackAmount)
    {
        this.itemType = itemType;
        this.stackAmount = stackAmount;
    }

    public ItemStack(ItemType itemType) : this(itemType, 1) { }
    public void useItem()
    {
        if (stackAmount < 1) return;
        switch (itemType)
        {
            case ItemType.Sword:
                playerDataHandler.instance.GetComponentInChildren<Sword>().Attack();
                int randomSwordSound = UnityEngine.Random.Range(0, 2);
                AudioClip[] swordSounds = { AudioManager.instance.swordsound1, AudioManager.instance.swordsound2, AudioManager.instance.swordsound3 };
                AudioManager.instance.PlaySFX(swordSounds[randomSwordSound]);
                break;

            case ItemType.HealthPotion:
                //check if 
                if (playerDataHandler.instance.GetComponentInChildren<Player_health>().health >= playerDataHandler.instance.GetComponentInChildren<Player_health>().maxHealth) break;
                playerDataHandler.instance.GetComponentInChildren<Player_health>().HealHealth(10);
                stackAmount--;
                AudioManager.instance.PlaySFX(AudioManager.instance.potionsound);
                break;

            case ItemType.ManaPotion:
                if (playerDataHandler.instance.GetComponentInChildren<Player_mana>().mana >= playerDataHandler.instance.GetComponentInChildren<Player_mana>().maxMana) break;
                playerDataHandler.instance.GetComponentInChildren<Player_mana>().RecoverMana(10);
                stackAmount--;
                AudioManager.instance.PlaySFX(AudioManager.instance.potionsound);
                break;

            case ItemType.Pickaxe:
                playerDataHandler.instance.GetComponentInChildren<Pickaxe>().Swing();
                break;

            case ItemType.Key:
                stackAmount--;
                break;
        }
        Debug.Log(itemType + " used! " + stackAmount + " remaining.");

        if (stackAmount <= 0)
        {
            playerDataHandler.instance.inventory.RemoveItem(this);
        }
    }

    public String getName()
    {
        return itemType.ToString();
    }
    public String getFormattedName()
    {
        return Regex.Replace(itemType.ToString(), "(?<!^)([A-Z])", " $1").Trim();
    }
}