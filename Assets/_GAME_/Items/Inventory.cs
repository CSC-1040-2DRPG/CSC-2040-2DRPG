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
        itemList.Add(item);
        Debug.Log(itemList.Count);
        activeItem1 = item;
    }
}
