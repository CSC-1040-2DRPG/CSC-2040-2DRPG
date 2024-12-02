using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DropChest : MonoBehaviour
{
    public GameObject chestPrefab;
    public ItemStack item;
    public String Guid;

    void OnDestroy()
    {
        GameObject chest = Instantiate(chestPrefab, transform.position, transform.rotation);
        chest.GetComponent<Chest>().itemName = new ItemStack(ItemStack.ItemType.Pickaxe);
        chest.GetComponent<Chest>().SetGuid(Guid);
        if(playerDataHandler.instance.inventory.HasItem(item.itemType)) {
            chest.GetComponent<Chest>().SetOpened();
        }
    }
}
