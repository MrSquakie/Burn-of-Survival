using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("PlayerSettings")]
    public float maxHealth;
    public float minThirst;
    public float minHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    public float health, thirst, hunger;
    private bool dead;
    public Slider healthBar, thirstBar, hungerBar, staminaBar;


    [Header("Object Interaction")]
    public bool canInteract; //is the player within distance to click object.
    public Camera playerCamera;
    public Text interactingObjectName;  //text from object interaction canvas
    public Material highlightMaterial;

    public void Start()
    {
        health = maxHealth;
        calculateHealthBar();
        canInteract = false;
    }

    public void Update()
    {
        //each frame update UI
        calculateHealthBar();
        calculateHungerBar();
        calculateThirstBar();
        calculateStats();
        interact();

        lookInteract();

        
    }
    public void calculateStats()
    {
        if (thirst > 0)
        {
            thirst -= thirstIncreaseRate * Time.deltaTime;
        }

        if (hunger > 0)
        {
            hunger -= hungerIncreaseRate * Time.deltaTime;
        }

        if (thirst <= 0)
        {
            Dehydrated();
        }
        if (hunger <= 0)
        {
            Starving();
        }
    }
    public float calculateHealthBar()
    {
        float normalizedHealth = health / maxHealth;
        healthBar.value = normalizedHealth;
        return normalizedHealth;
    }

    public void calculateThirstBar()
    {
        float normalizedThirst = thirst / minThirst;
        thirstBar.value = normalizedThirst;
    }

    public void calculateHungerBar()
    {
        float normalizedHunger = hunger / minHunger;
        hungerBar.value = normalizedHunger;
    }

    public void Starving()
    {
        if (checkAlive())
            health -= hungerIncreaseRate * 2 * Time.deltaTime;
    }
    public void Dehydrated()
    {
        if (checkAlive())
            health -= thirstIncreaseRate * 2 * Time.deltaTime;
    }
    public bool checkAlive()
    {
        if (health <= 0)
        {
            Die();
            return false;
        }
        return true;
    }

    public void Die()
    {
        if (!dead) {
            dead = true;
        }
        
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        calculateHealthBar();  //healthbar update
    }

    public void heal(float _healAmount)
    {
        health += _healAmount;
        calculateHealthBar();  //healthbar update
    }
    public void Drink(float increaseRate)
    {

        if (thirst < 100)
        {
            thirst += increaseRate;
        }
    }


    public void interact()  //click raycast, click an object to interact with it.
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.DrawRay(ray.origin, ray.direction * 500, Color.red, 2 * Time.deltaTime);
            }
        }
    }

    private Transform _selection;

    /// <summary>
    /// Raycast to an object and if it has the item component and is marked as interactable change the material.
    /// If we stop looking at the object, reset the material- (_seletion != null) part
    /// </summary>
    public void lookInteract() //where the player is looking highlight object, different from click raycast. 
    {
        
        if (_selection != null)
        {
            Material selectionMaterial = _selection.GetComponent<Item>().itemMaterial;
            Renderer meshRenderer = _selection.GetComponent<Renderer>();
            meshRenderer.material = selectionMaterial;
            _selection = null;
        }
        
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
         //turns of raycast hitting trigger colliders.
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, hit.transform.position * 1000, Color.green);
            //if looking at object get object's name and type.
            //when raycast hits item change materials[1] to highlightMaterial
            Transform hitObject = hit.transform;
            interactingObjectName.text = hitObject.name;
            if (hitObject.GetComponent<Item>()) { 
                Item item = hitObject.GetComponent<Item>();
                if (item.interactable)
                {
                    Renderer mat = hitObject.GetComponent<Renderer>();
                    mat.material = highlightMaterial;

                        objectInteract(item);
                }
                _selection = hitObject;
            }
        }
    }

    public void objectInteract(Item item)
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract) {
            if (item.type == Item.ItemType.lake)
            {
                Drink(item.thirstRechargeAmount);
            }
        }
    }

    /// <summary>
    /// is the player within a trigger object that has an item component? 
    /// These triggers are set as the interact distance,so set to true
    /// </summary>
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() != null)
        {
            print("in zone");
            canInteract = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Item>() != null)
        {
            canInteract = false;
        }
    }
}
