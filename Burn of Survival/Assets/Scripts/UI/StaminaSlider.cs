using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaSlider : MonoBehaviour
{
    public Player playerVars;
    public float stamina, maxStamina, staminaDecreaseRate;
    public Slider staminaBar;
    
    public void Start()
    {
        playerVars = GameObject.FindWithTag("Player").GetComponent<Player>();
        staminaBar = GetComponent<Slider>();
        stamina = playerVars.stamina;
        maxStamina = playerVars.maxStamina;
        staminaDecreaseRate = playerVars.staminaDecreaseRate;
    }

    public void Update()
    {
        calculateStamina();
    }


    public void calculateStamina()
    {
        stamina = playerVars.stamina;
        if (stamina > 0 && playerVars.canRun)
        {
            stamina -= staminaDecreaseRate*Time.deltaTime;
        }
        float normalizedStamina = stamina / maxStamina;
        staminaBar.value = normalizedStamina;
        playerVars.stamina = stamina;
    }
}
