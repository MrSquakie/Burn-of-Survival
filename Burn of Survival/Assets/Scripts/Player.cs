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

    public Camera playerCamera;

    public Text interactingObjectName;  //text from object interaction canvas

    public Material highlightMaterial;

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

        interact();

        lookInteract();

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
        thirst += increaseRate;
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
    private Material defaultMaterial;
    public void lookInteract() //where the player is looking highlight object, different from click raycast. 
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
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
                }
                _selection = hitObject;
            }
        }
    }
}
