using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;

    public float lifetime = 3f;


    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
