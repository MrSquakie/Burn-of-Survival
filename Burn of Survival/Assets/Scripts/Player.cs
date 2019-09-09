using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    [Header("PlayerSettings")]

    public float maxThirst, maxHunger, maxHealth, maxStamina;
    public float thirstIncreaseRate, hungerIncreaseRate, staminaIncreaseRate, staminaDecreaseRate;
    public float health, thirst, hunger, stamina;
    private bool dead;
    public bool canRun;
    public RigidbodyFirstPersonController fpsController;

    [Header("Object Interaction")]
    public bool canInteract; //is the player within distance to click object.
    public Camera playerCamera;
    public Text interactingObjectName;  //text from object interaction canvas
    public Material highlightMaterial;

    public void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
        health = maxHealth;
        canInteract = false;
    }

    public void Update()
    {
        //each frame update UI
        calculateStats();
      
        canRunCheck();

    }

    public void canRunCheck()
    {
        if (stamina > 0)
        {
            canRun = true;
        }
        else
        {
            canRun = false;
        }
    }

    public void calculateStats()
    {
        if (thirst <= 0)
        {
            Dehydrated();
        }
        if (hunger <= 0)
        {
            Starving();
        }
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
        if (thirst > maxThirst)
        {
            thirst = maxThirst;
        }
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
    }

    public void heal(float _healAmount)
    {
        health += _healAmount;
    }

    public void Drink(float increaseRate)
    {

        if (thirst < 100)
        {
            thirst += increaseRate;
        }
    }
    public void Eat(float increaseRate)
    {
        if (hunger < 100)
        {
            hunger += increaseRate;
        }
    }

}
