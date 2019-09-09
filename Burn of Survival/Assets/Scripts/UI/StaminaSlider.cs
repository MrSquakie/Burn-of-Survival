using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public Player playerVars;
    public float stamina, maxStamina, staminaDecreaseRate, staminaIncreaseRate, timer;
    public Slider staminaBar;

    private float normalizedStamina;
    public void Start()
    {
        timer = 5;
        playerVars = GameObject.FindWithTag("Player").GetComponent<Player>();
        staminaBar = GetComponent<Slider>();
        stamina = playerVars.stamina;
        maxStamina = playerVars.maxStamina;
        staminaDecreaseRate = playerVars.staminaDecreaseRate;
        staminaIncreaseRate = playerVars.staminaIncreaseRate;
    }

    public void Update()
    {
        calculateStamina();
        rechargeStamina();
    }


    public void calculateStamina()
    {
        stamina = playerVars.stamina;
        if (stamina > 0 && playerVars.fpsController.Running)
        {
            stamina -= staminaDecreaseRate*Time.deltaTime;
        }
        normalizedStamina = stamina / maxStamina;
        staminaBar.value = normalizedStamina;
        playerVars.stamina = stamina;
    }

    public void rechargeStamina()
    {
        if (timer > 5f)
        {
            stamina += staminaIncreaseRate * Time.deltaTime;
            playerVars.stamina = stamina;
            calculateStamina();
        }
        else
        {
            timer += 1 * Time.deltaTime;
        }
    }
}
