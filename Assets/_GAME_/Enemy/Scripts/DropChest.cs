using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}
