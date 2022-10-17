using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigosCorpoaCorpo : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public GameObject player;
    float speed, dist_max;
    public Rigidbody rigidbody_enemy;
    bool inimigo1, inimigo2, player_in_area, inimigo3;

    float cooldownTime = 2;
    float nextFireTime = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        if (transform.tag == "InimigoCorpoaCorpo")
        {
            speed = 1.0f;
            dist_max = 8.0f;
            inimigo1 = true;
        }

        if (transform.tag == "InimigoAlcance")
        {
            speed = 0.6f;
            dist_max = 16.0f;
            inimigo2 = true;
        }

        if (transform.tag == "InimigoBoss")
        {
            inimigo3 = true;
            inimigo1 = false;
            inimigo2 = false;
            speed = 3.0f;
        }
    }


    void Update()
    {
        transform.LookAt(player.transform);
        if (inimigo1)
        {
            AtaqueCorpoaCorpo();
        }


        if (inimigo2 && player_in_area)
        {
            if (Time.time > nextFireTime)
            {
                AtaqueAlcance();
            }
        }

        if (inimigo3)
        {
            Perseguir();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") player_in_area = true;
    }

    void AtaqueCorpoaCorpo()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= dist_max && inimigo1)
        {
            Perseguir();
        }
        else
        {
            Normal();
        }
    }

    void Perseguir()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void Normal()
    {
        transform.position += transform.forward * 0 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
    }

    void AtaqueAlcance()
    {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * 50;

        nextFireTime = Time.time + cooldownTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_in_area = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) <= 10.0f && other.name== "Rajadadevento")
        {
            transform.position -= transform.forward *2.0f* speed;
        }
       
    }


}
