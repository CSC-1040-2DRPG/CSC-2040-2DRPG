using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour, IDataPersistence
{
    [SerializeField] public BoxCollider2D boxCollider;
    [SerializeField] public Item item;
    [SerializeField] private String chestID;
    [SerializeField] private Sprite openSprite;
    public bool opened = false;
    private bool playerInRange = false;
    // Start is called before the first frame update
    
    
    private void OnTriggerEnter2D(Collider2D collision) {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        playerInRange = false;
    }

    public void Update(){
        if(Input.GetKey(KeyCode.E) && playerInRange){
            Open();
        }
    }

    public void Open(){
        if(opened) return;
        opened = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
    }

    public void LoadData(GameData data) 
    {
        data.chestsOpen.TryGetValue(chestID, out opened);
        if (opened){
            gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
        }
    }

    public void SaveData(GameData data) 
    {
        if (data.chestsOpen.ContainsKey(chestID))
        {
            data.chestsOpen.Remove(chestID);
        }
        data.chestsOpen.Add(chestID, opened);
    }
}
