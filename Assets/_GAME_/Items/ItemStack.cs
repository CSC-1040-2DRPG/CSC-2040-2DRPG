using System;
using System.Collections;
using System.Collections.Generic;
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

    public ItemStack(ItemType itemType, int stackAmount){
        this.itemType = itemType;
        this.stackAmount = stackAmount;
    }

    public ItemStack(ItemType itemType){
        this.itemType = itemType;
        this.stackAmount = 1;
    }

    public void useItem(){
        Debug.Log(itemType + " used!");
        if(itemType == ItemType.Sword && stackAmount > 0){
            //call sword use method here
        }
    }
}
