using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public Slider qtd_vida;
    public bool isdead, atingido;

    void Start()
    {
        
    }


    void Update()
    {
        if (qtd_vida.value <= 0)
        {
            isdead = true;
        }
    }

    public void TakeDamage()
    {
       
            qtd_vida.value -= 5.0f * Time.deltaTime;
        
    }


  



}
