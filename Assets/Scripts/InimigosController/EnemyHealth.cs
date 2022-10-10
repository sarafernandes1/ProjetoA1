using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int vida = 100;
    bool isdead = false;


    void Start()
    {
        if (transform.tag == "InimigoAlcance")
        {
            vida = 200;
        }
        if (transform.tag == "Boss")
        {
            vida = 400;
        }
    }


    void Update()
    {
        if (vida <= 0)
        {
            isdead = true;
            IsDead();
        }
    }

    public void IsDead()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.gameObject.name == "AtaqueNormal")
        {
            vida -= 2;
        }
        if (other.gameObject.name == "Boladefogo")
        {
            vida -= 10;
        }
        if (other.gameObject.name == "RaioEletrico")
        {
            vida -= 20;
        }
        if (other.gameObject.name == "Rajadadevento")
        {
            vida -= 30;
        }
    }


}
