using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool empty;

    public GameObject item;
    public Texture itemIcon;

    public bool hovered;
    void Start()
    {
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

}
