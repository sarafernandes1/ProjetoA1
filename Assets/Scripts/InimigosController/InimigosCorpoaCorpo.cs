using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigosCorpoaCorpo : MonoBehaviour
{
    public GameObject player;
    float speed, dist_max;
    public Rigidbody rigidbody_enemy;
    bool inimigo1, inimigo2, player_in_area;

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
        if (inimigo2 && player_in_area)
        {
            AtaqueAlcance();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Player") player_in_area = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag=="Player") player_in_area = false;
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
        //feitiço->jogador
    }

    private void OnParticleCollision(GameObject other)
    {
        if (Vector3.Distance(transform.position, other.transform.position) <= 6.0f && other.name== "Rajadadevento")
        {
            transform.position -= transform.forward *2.0f* speed;
        }
       
    }


}
