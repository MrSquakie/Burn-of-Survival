using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaterSlider : MonoBehaviour
{
    public Player playerVars;
    public float minThirst, thirst, thirstIncreaseRate;
    public Slider waterSlider;
    void Start()
    {
        waterSlider = GetComponent<Slider>();
        playerVars = GameObject.FindWithTag("Player").GetComponent<Player>();
        thirst = playerVars.thirst;
        thirstIncreaseRate = playerVars.thirstIncreaseRate;
        minThirst = playerVars.maxThirst;
    }

    // Update is called once per frame
    void Update()
    {
        calculateThirstBar();

    }
    public void calculateThirstBar()
    {
        thirst = playerVars.thirst;
        if (thirst > 0)
        {
            thirst -= thirstIncreaseRate * Time.deltaTime;
        }
        float normalizedThirst = thirst / minThirst;
        waterSlider.value = normalizedThirst;
        playerVars.thirst = thirst;
    }
}
