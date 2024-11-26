using UnityEngine;
using UnityEngine.UIElements;

public class ItemSlot
{
    public Button button;
    public ItemStack item;

    public ItemSlot(ItemStack item, VisualTreeAsset template)
    {
        this.item = item;

        // Instantiate the template to create the UI container.
        TemplateContainer itemContainer = template.Instantiate();

        // Find the button element in the container.
        button = itemContainer.Q<Button>();

        // Set the button's text to display item name and stack amount.
        if (button != null && this.item != null)
        {
            button.text = $"{this.item.getName()} : {this.item.stackAmount}";

            // Register the PointerDown event and link it to the OnPointerDown method.
            button.RegisterCallback<PointerDownEvent>(OnPointerDown, TrickleDown.TrickleDown);
        }
        else
        {
            Debug.LogError("Button or Item is null. Ensure the UI and ItemStack are properly initialized.");
        }
    }

    // This method will handle the PointerDown events.
    private void OnPointerDown(PointerDownEvent evt)
    {
        if (evt.button == 0)
        {
            playerDataHandler.instance.inventory.setActive1(item);
        }
        else if (evt.button == 1)
        {
            playerDataHandler.instance.inventory.setActive2(item);
        }

        // Stop the event from propagating to prevent the default button behavior.
        evt.StopImmediatePropagation();
    }
}
