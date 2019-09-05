using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float maxHealth, minThirst, minHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
   
    public float health, thirst, hunger;
    private bool dead;

    public Slider healthBar, thirstBar, hungerBar, staminaBar;
    
    public void Start()
    {
        health = maxHealth;
        calculateHealthBar();
        
    }

    public void Update()
    {
        //each frame update UI
        calculateHealthBar();
        calculateHungerBar();
        calculateThirstBar();

        ///temp///////////////////////////////
      
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(5f);
        }

        //////////////////////////////

        


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
        print(_damage);
        health -= _damage;
        calculateHealthBar();  //healthbar update
    }

    public void heal(float _healAmount)
    {
        print(_healAmount);
        health += _healAmount;
        calculateHealthBar();  //healthbar update
    }
    public void Drink(float increaseRate)
    {
        thirst += increaseRate;
    }
}
