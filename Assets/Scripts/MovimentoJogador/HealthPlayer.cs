using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public Slider qtd_vida;
    bool isdead;

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

}
