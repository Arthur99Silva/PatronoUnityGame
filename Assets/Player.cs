using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {   //K SALVA
        if(Input.GetKeyDown(KeyCode.K))
        {
            inventory.Save();
        }
        if(Input.GetKeyDown(KeyCode.J)) // J CARREGA
        {
            inventory.Load();
        }
    }
    
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[50];
    }
}
