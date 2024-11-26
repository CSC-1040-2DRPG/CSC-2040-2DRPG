using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Inventory
{
    [SerializeField] public List<ItemStack> itemList;
    [SerializeField] public ItemStack activeItem1;
    [SerializeField] public ItemStack activeItem2;

    public Inventory(){
        itemList = new List<ItemStack>();
        activeItem1 = null;
        activeItem2 = null;
    }

    public void AddItem(ItemStack item){
        bool itemExists = false;
        foreach(ItemStack i in itemList){
            if (i.itemType == item.itemType){
                i.stackAmount += item.stackAmount;
                itemExists = true;
            }
        }
        if(!itemExists) itemList.Add(item);
        Debug.Log(itemList.Count);
    }

    public void setActive1(ItemStack item){
        activeItem1 = item;
    }

    public void setActive2(ItemStack item){
        activeItem2 = item;
    }
}
