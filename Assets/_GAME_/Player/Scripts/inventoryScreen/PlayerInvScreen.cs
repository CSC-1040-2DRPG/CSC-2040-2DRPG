using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInvScreen : MonoBehaviour
{
    UIDocument uiInv;
    public VisualTreeAsset ItemSelectTemplate;
    TemplateContainer itemSel;

    void OnEnable(){
        uiInv = GetComponent<UIDocument>();
        itemSel = ItemSelectTemplate.Instantiate();
        
        refreshScreen();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            gameObject.transform.parent.transform.parent.GetComponent<Player_Controller>().enabled = true;
            uiInv.enabled = false;
            enabled = false;
        }
        
    }

    void refreshScreen(){ 
        foreach(ItemStack i in playerDataHandler.instance.inventory.itemList){
            ItemSlot itemSlot = new ItemSlot(i, ItemSelectTemplate);

            uiInv.rootVisualElement.Q("BG").Add(itemSlot.button);
        }
    }

}
