
using System.Diagnostics;
using UnityEngine.UIElements;

public class ItemSlot
{
    public Button button;
    public ItemStack item;
    public ItemSlot(ItemStack item, VisualTreeAsset template){
        this.item = item;
        TemplateContainer itemContainer = template.Instantiate();
        
        button = itemContainer.Q<Button>();

        button.text = this.item.getName();

        button.RegisterCallback<ClickEvent>(onClick);
    }

    public void onClick(ClickEvent evt){
        playerDataHandler.instance.inventory.activeItem1 = item;
        UnityEngine.Debug.Log( item.getName() + " Button Pushed");
    }
}
