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
        var existingItem = itemList.Find(i => i.itemType == item.itemType);

        if (existingItem != null){
            // If item exists, update its stack amount
            existingItem.stackAmount += item.stackAmount;
        } else {
            // Otherwise, add the new item to the inventory
            itemList.Add(item);
        }

        Debug.Log($"Inventory size: {itemList.Count}");
    }

    public void RemoveItem(ItemStack.ItemType itemType, int countToRemove) {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].itemType == itemType) {
                // Decrease the stack amount
                itemList[i].stackAmount -= countToRemove;

                if (itemList[i].stackAmount < 1) {
                    itemList.RemoveAt(i);
                }
            }
        }

        Debug.Log("Item of type " + itemType + " not found in inventory.");
    }

    public void RemoveItem(ItemStack.ItemType itemType) {
        // Find the first item in the inventory matching the specified type
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].itemType == itemType) {
                itemList.RemoveAt(i);
            }
        }

        Debug.Log("Item of type " + itemType + " not found in inventory.");
    }

    public void setActive1(ItemStack item){
        activeItem1 = item;
    }

    public void setActive2(ItemStack item){
        activeItem2 = item;
    }
}
