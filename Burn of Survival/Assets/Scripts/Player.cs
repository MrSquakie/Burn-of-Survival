using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
   
    private float health, thirst, hunger;
    private bool dead;
    public void Start()
    {
        health = maxHealth;

        
    }

    public void Update()
    {
        if (thirst < maxThirst)
        {
            thirst += thirstIncreaseRate * Time.deltaTime;
        }

        if (hunger < maxHunger)
        {
            hunger += hungerIncreaseRate * Time.deltaTime;
        }

        if (thirst >= maxThirst)
        {
            Die();
        }
        if (hunger >= maxHunger)
        {
            Die();
        }
        
    }

    public void Die()
    {
        if (!dead) {
            print("You done fucked up");
            dead = true;
        }
        
    }
}
