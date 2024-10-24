using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Inventory
{
    [SerializeField] private List<ItemStack> itemList;
    [SerializeField] public ItemStack activeItem1;
    [SerializeField] public ItemStack activeItem2;

    public Inventory(){
        itemList = new List<ItemStack>();
    }

    public void AddItem(ItemStack item){
        bool alreadyHas = false;
        foreach(ItemStack i in itemList){
            if (i.itemType == item.itemType) {
                i.stackAmount += item.stackAmount;
                alreadyHas = true;
                Debug.Log("got " + item.stackAmount + " " + item.itemType + "(s), " + i.stackAmount + " in total");
            }
        }
        if(!alreadyHas) {
            itemList.Add(item);
            activeItem1 = item;
            Debug.Log("got " + item.stackAmount + " " + item.itemType + "(s)");
        }
    }
}
