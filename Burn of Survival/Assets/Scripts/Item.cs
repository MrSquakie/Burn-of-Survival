using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  
    public Texture icon;
    public string type;

    public float thirstRechargeAmount;
    public bool interactable;
    public bool canPickUp;

    public Material itemMaterial;

    public void Start()
    {
        itemMaterial = GetComponent<Renderer>().material;
    }
}
