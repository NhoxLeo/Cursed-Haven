using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("Health property")]
    public int maxHealthValue = 200;
    public int currentHealthValue;
    public Slider playerHealthSlider;




    void Start()
    {
        currentHealthValue = maxHealthValue;
        playerHealthSlider.maxValue = maxHealthValue;
       
    }

    private void Update()
    {
        playerHealthSlider.value = currentHealthValue;

       


    }

}
