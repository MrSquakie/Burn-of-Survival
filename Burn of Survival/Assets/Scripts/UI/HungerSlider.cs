using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HungerSlider : MonoBehaviour
{
    public float minHunger, hunger, hungerIncreaseRate;
    public Slider hungerBar;
    public Player playerVars;
    // Start is called before the first frame update
    void Start()
    {
        playerVars = GameObject.FindWithTag("Player").GetComponent<Player>();
        hungerBar = GetComponent<Slider>();
        minHunger = playerVars.minHunger;
        hunger = playerVars.hunger;
        hungerIncreaseRate = playerVars.hungerIncreaseRate;
    }

    // Update is called once per frame
    void Update()
    {
        calculateHungerBar();

    }
    public void calculateHungerBar()
    {
        hunger = playerVars.hunger;
        if (hunger > 0)
        {
            hunger -= hungerIncreaseRate * Time.deltaTime;
        }
        float normalizedHunger = hunger / minHunger;
        hungerBar.value = normalizedHunger;
        playerVars.hunger = hunger;

    }

}
