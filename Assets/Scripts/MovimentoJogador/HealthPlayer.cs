using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public Slider qtd_vida;
    public bool isdead;

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

    public void TakeDamage(float damage)
    {
        qtd_vida.value -= damage * Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name == "Ataque1")
        {
            qtd_vida.value -= 0.3f*Time.deltaTime;
        }
    }

}
