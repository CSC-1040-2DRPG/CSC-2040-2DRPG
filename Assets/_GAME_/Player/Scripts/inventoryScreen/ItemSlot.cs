
using UnityEngine.UIElements;

public class ItemSlot
{
    public Button button;
    public ItemSlot(ItemStack item, VisualTreeAsset template){
        TemplateContainer itemContainer = template.Instantiate();
        
        button = itemContainer.Q<Button>();
    }
}
