using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool empty;

    public GameObject item;
    public Texture itemIcon;

    private GameObject player;

    public bool hovered;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hovered = false;
    }

    void Update()
    {
        if (item)
        {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            empty = true;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();
            //check item type
            if(thisItem.type == "water")
            {
                Player playerScript = player.GetComponent<Player>(); //this references the player script
                if (playerScript.checkAlive())
                    playerScript.Drink(thisItem.thirstRechargeAmount);
            }
        }
    }
}
