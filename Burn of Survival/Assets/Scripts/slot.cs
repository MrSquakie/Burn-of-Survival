using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool empty;

    public GameObject item;
    public Texture itemIcon, defaultIcon;

    private GameObject player;

    public bool hovered;
    void Start()
    {
        this.GetComponent<RawImage>().texture = defaultIcon;
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
            this.GetComponent<RawImage>().texture = defaultIcon;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("entered");

        hovered = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        print("drink");
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();
            //check item type
            Player playerScript = player.GetComponent<Player>(); //this references the player script

            if (playerScript.checkAlive())
            {
                if (thisItem.type == Item.ItemType.water)
                {
                    //drink water
                    playerScript.Drink(thisItem.thirstRechargeAmount);
                    empty = true;
                    item = null;
                    itemIcon = defaultIcon;
                }
                if (thisItem.type == Item.ItemType.food)
                {
                    //eat food
                    playerScript.Eat(thisItem.hungerRechargeAmount);
                    empty = true;
                    item = null;
                    itemIcon = defaultIcon;
                }
            }
        }
    }
}
