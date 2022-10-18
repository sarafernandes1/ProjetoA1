using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody enemy;
    public Slider qtd_vida;
    public ParticleSystem particle1;
    float speed = 1.0f;
    int n_inimigos;
    float cooldownTime = 10, cooldownAtaque = 6;
    float nextFireTime = 0, nextenemy = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        transform.LookAt(player.transform);
        if (distanceToPlayer <= 30.0f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Time.time > nextFireTime)
            {
                Ataque();
            }
        }
        if (distanceToPlayer <= 50.0f)
        {
            if (Time.time > nextenemy && n_inimigos <= 4)
            {
                PosicionarInimigo();
            }
        }
        

        if (distanceToPlayer <= 60.0f)
        {
            qtd_vida.gameObject.SetActive(true);
        }
        else
        {
            qtd_vida.gameObject.SetActive(false);
        }

    }

    void Ataque()
    {
        particle1.Play();
        nextFireTime = Time.time + cooldownAtaque;
    }

    void PosicionarInimigo()
    {
        var inimigo_chamdo1 = Instantiate(enemy, new Vector3(transform.position.x+Random.value, 5.0f, transform.position.z), transform.rotation);
        var inimigo_chamdo2 = Instantiate(enemy, new Vector3(transform.position.x, 5.0f, transform.position.z + Random.value), transform.rotation);
        n_inimigos += 2;
        inimigo_chamdo1.velocity = transform.forward * 20;
        inimigo_chamdo2.velocity = transform.forward * 30;
        nextenemy = Time.time + cooldownTime;
    }
}
