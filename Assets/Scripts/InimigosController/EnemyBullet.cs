using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthPlayer healthPlayer = collision.transform.GetComponent<HealthPlayer>();
            healthPlayer.TakeDamage();
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Chão")
        {
            Destroy(gameObject);
        }

    }
}
