using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;

    public float lifetime = 3f;

    public bool enemy_bullet = false;
    public float bullet_radius = 0.5f;
    public LayerMask player_layer;

    public AudioClip hit_sound;

    public GameObject hit_effect;


    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Enemy Bullet
        if(enemy_bullet)
        {
            if(Physics.CheckSphere(transform.position, bullet_radius, player_layer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Hit to enemy
        if (other.CompareTag("Enemy"))
        {
            GameObject drone = other.transform.parent.gameObject;
            drone.GetComponent<Drone>().health -= 25f;
            //Sound Effect
            drone.GetComponent<AudioSource>().PlayOneShot(hit_sound);
        }

        //Hit Effect

        Instantiate(hit_effect, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }
}
