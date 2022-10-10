using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int vida = 100;
    bool isdead = false;
    public GameObject drop;

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
        drop.SetActive(true);
        drop.transform.position = gameObject.transform.position;
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
            AtaqueBolaFogo(other);
            other.SetActive(true);
        }
        if (other.gameObject.name == "RaioEletrico")
        {
            AtaqueEletrico(other);
            other.SetActive(true);
        }
        if (other.gameObject.name == "Rajadadevento")
        {
            vida -= 30;
        }
    }

    public void AtaqueEletrico(GameObject raioeletrico)
    {
        vida -= 20;
        raioeletrico.SetActive(false);
    }

    public void AtaqueBolaFogo(GameObject bolafogo)
    {
        float distanceToExplosion = Vector3.Distance(bolafogo.transform.position, transform.position);

        if (distanceToExplosion < 4.0f)
        {
            vida -= 10;
        }

        if (distanceToExplosion >= 4.0f && distanceToExplosion<6.0f)
        {
            vida -= 6;
        }

        if (distanceToExplosion>=6.0f && distanceToExplosion<10.0f)
        {
            vida -= 2;
        }

        bolafogo.SetActive(false);
    }

}
