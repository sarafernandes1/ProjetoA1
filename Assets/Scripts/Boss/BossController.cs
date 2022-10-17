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
    float speed = 1.2f;
    int n_inimigos;
    float cooldownTime = 10;
    float nextFireTime = 0;
    float nextenemy = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        transform.LookAt(player.transform);
        if ( distanceToPlayer <= 60.0f)
        {
            qtd_vida.gameObject.SetActive(true);
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Time.time > nextFireTime)
            {
                Ataque();
            }
            if(Time.time > nextenemy && n_inimigos<=4)
            {
                PosicionarInimigo();
            }
        }
        else
        {
            qtd_vida.gameObject.SetActive(false);
        }
    }

    void Ataque()
    {
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
