using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public float health, maxHealth;
    public Slider healthBar;
    private GameObject player;
    private Player playerVars;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        player = GameObject.FindWithTag("Player");
        playerVars = player.GetComponent<Player>();
        health = playerVars.maxHealth;
        maxHealth = playerVars.maxHealth;
        calculateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        calculateHealthBar();
    }

    public float calculateHealthBar()
    {
        health = playerVars.health;
        float normalizedHealth = health / maxHealth;
        healthBar.value = normalizedHealth;
        return normalizedHealth;
    }
}
