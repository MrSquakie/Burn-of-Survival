using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Canvas inventory;
    public GameObject slotHolder;
    private bool inventoryEnabled = false;

    public int slots;
    public Transform[] slot;

    private GameObject itemPickedUp;
    private bool itemAdded;

    public void Start()
    {
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        DetectInventorySlots();
        inventory.enabled = false;

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryEnabled)
            {
                inventory.enabled = false;
                inventoryEnabled = false;
            }
            else
            {
                inventoryEnabled = true;
                inventory.enabled = true;
            }
        }
    }
    public void toggleInventory()
    {
        
    }

    public void DetectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemAdded = false;
        }
    }

    public void AddItem(GameObject _item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<slot>().empty && !itemAdded)
            {
                slot[i].GetComponent<slot>().item = _item;
                itemAdded = true;
            }
        }
    }
    
}
    
