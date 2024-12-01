using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class HotBar : MonoBehaviour
{
    UIDocument uiInv;
    VisualElement leftSlot;
    VisualElement rightSlot;
    TemplateContainer itemSel;

    void OnEnable()
    {
        uiInv = GetComponent<UIDocument>();
        leftSlot = uiInv.rootVisualElement.Q("hotbar").Q<VisualElement>("leftSlot");
        rightSlot = uiInv.rootVisualElement.Q("hotbar").Q<VisualElement>("rightSlot");
    }

    private void Update()
    {
        refreshHotbar();
    }

    public void refreshHotbar()
    {
        refreshSlot(leftSlot, playerDataHandler.instance.inventory.activeItem1);
        refreshSlot(rightSlot, playerDataHandler.instance.inventory.activeItem2);
    }

    private void refreshSlot(VisualElement slot, ItemStack.ItemType itemType)
    {
        ItemStack item = null;
        foreach (ItemStack i in playerDataHandler.instance.inventory.itemList)
        {
            if (i.itemType == itemType)
            {
                item = i;
            }
        }
        if (item == null)
        {
            clearSlot(slot);
            return;
        }
        if (item.itemType == ItemStack.ItemType.None)
        {
            clearSlot(slot);
            return;
        }

        if (item.stackAmount != 1)
        {
            slot.Q<Label>().text = item.stackAmount.ToString();
        }
        else
        {
            slot.Q<Label>().text = "";
        }

        string imagePath = $"Assets/_GAME_/Items/ItemSprites/InvIcons/{item.getName()}.png";

        if (File.Exists(imagePath))
        {
            // Load the image as a Texture2D.
            Texture2D texture = ItemSlot.LoadTexture(imagePath);
            if (texture != null)
            {
                // Set the background image.
                slot.style.backgroundImage = new StyleBackground(texture);
            }
            else
            {
                Debug.LogError($"Failed to load texture from {imagePath}");
            }
        }
        return;
    }

    private void clearSlot(VisualElement slot)
    {
        slot.style.backgroundImage = null;
        slot.Q<Label>().text = "";
    }
}
