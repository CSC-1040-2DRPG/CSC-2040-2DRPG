using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSlot
{
    public Button button;
    public VisualElement image;
    public ItemStack item;

    public ItemSlot(ItemStack item, VisualTreeAsset template)
    {
        this.item = item;

        // Instantiate the template to create the UI container.
        TemplateContainer itemContainer = template.Instantiate();

        // Find the button and image element in the container.
        button = itemContainer.Q<Button>();
        image = itemContainer.Q<VisualElement>("Image");
        //image = button.Q<VisualElement>("Image");

        if (image != null && item != null)
        {
            string imagePath = $"Assets/_GAME_/Items/ItemSprites/InvIcons/{item.getName()}.png";

            if (File.Exists(imagePath))
            {
                // Load the image as a Texture2D.
                Texture2D texture = LoadTexture(imagePath);
                if (texture != null)
                {
                    // Set the background image.
                    image.style.backgroundImage = new StyleBackground(texture);
                }
                else
                {
                    Debug.LogError($"Failed to load texture from {imagePath}");
                }
            }
            else
            {
                Debug.LogWarning($"Image file not found: {imagePath}");
            }
        } else {
            Debug.LogError("No Image container in the itemContainer");
        }

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

    private static Texture2D LoadTexture(string path)
    {
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2); // Create a small temp texture.
        if (texture.LoadImage(fileData)) // Load the image data into the texture.
        {
            texture.filterMode = FilterMode.Point; // Set the filter mode to Point.
            texture.Apply();
            return texture;
        }
        return null;
    }
}
