using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;
    private bool inventoryEnabled = false;

    public int slots;
    public Transform[] slot;

    private GameObject itemPickedUp;

    public void Start()
    {
        slots = slotHolder.transform.childCount;
        print(slots);
        slot = new Transform[slots];

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            print("yo");
            if (inventoryEnabled)
            {
                inventory.SetActive(false);
                inventoryEnabled = false;
            }
            else
            {
                inventoryEnabled = true;
                inventory.SetActive(true);
            }
        }
    }
    public void toggleInventory()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Item>())
        {
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<slot>.empty)
            {

            }
        }
    }
    
}
    
