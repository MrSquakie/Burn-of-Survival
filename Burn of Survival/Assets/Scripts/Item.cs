using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  
    public Texture icon;

    public float thirstRechargeAmount, hungerRechargeAmount;
    public bool interactable;
    public bool canPickUp;

    public Material itemMaterial;
    public enum ItemType { water, food, lake};
    public ItemType type;

    public void Start()
    {
        itemMaterial = GetComponent<Renderer>().material;
    }
}
