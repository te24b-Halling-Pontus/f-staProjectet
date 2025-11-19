using System;
using UnityEngine;

public class boltcontroller : MonoBehaviour
{

    [SerializeField]
    float boltspeed = 100f;
    void Update()
    {
        transform.Translate(Vector2.up * boltspeed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "elaking")
        {
            Destroy(gameObject);
        }
    }
}