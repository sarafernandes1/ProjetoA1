using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject player;
    public Slider qtd_vida;
    public ParticleSystem particle1;
    float speed = 20.0f;

    float cooldownTime = 10;
    float nextFireTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (/*Time.time > nextFireTime &&*/ distanceToPlayer <= 60.0f)
        {
                Ataque();
        }
        else
        {
            qtd_vida.gameObject.SetActive(false);
        }
    }

    void Ataque()
    {
        //particle1.Play();

        transform.Rotate(0.0f,speed * Time.deltaTime,0.0f,Space.Self);
        //nextFireTime = Time.time + cooldownTime;

    }
}
