using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
   
    public float health, thirst, hunger;
    private bool dead;

    public Slider healthBar;
    
    public void Start()
    {
        health = maxHealth;
        healthBar.value = calculateHealth();
        
    }

    public void Update()
    {

        ///temp///////////////////////////////
      
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(5f);
            print("hit");
        }

        //////////////////////////////

        


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

    public float calculateHealth()
    {
        print("recalculatng");
        return health / maxHealth;
    }


    public void Die()
    {
        if (!dead) {
            print("You done fucked up");
            dead = true;
        }
        
    }

    public void TakeDamage(float _damage)
    {
        print(_damage);
        health -= _damage;
        calculateHealth();  //healthbar update
    }

    public void heal(float _healAmount)
    {
        print(_healAmount);
        health += _healAmount;
        calculateHealth();  //healthbar update
    }
    public void Drink(float decreaseRate)
    {
        thirst -= decreaseRate;
    }
}
