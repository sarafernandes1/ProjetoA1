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
    public bool inimigo1, inimigo2, player_in_area;

    public Slider qtd_vida;

    float cooldownTime = 2;
    float nextFireTime = 0;

    void Start()
    {
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
    }


    void Update()
    {
        transform.LookAt(player.transform);
        if (inimigo1)
        {
            AtaqueCorpoaCorpo();
        }


        if (inimigo2)
        {
            if (Time.time > nextFireTime)
            {
                AtaqueAlcance();
            }
        }

    }

   

    void AtaqueCorpoaCorpo()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= dist_max && inimigo1)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        else
        {
            transform.position += transform.forward * 0 * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }
    }

    void AtaqueAlcance()
    {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * 50;

        Ray ray_ = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray_,out RaycastHit hit,100))
        {
            if (hit.collider.tag == "Player")
            {
                qtd_vida.value -=6.0f * Time.deltaTime;
            }
        }

        nextFireTime = Time.time + cooldownTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss") player_in_area = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") player_in_area = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) <= 6.0f && other.name== "Rajadadevento")
        {
            transform.position -= transform.forward *2.0f* speed;
        }
       
    }


}
