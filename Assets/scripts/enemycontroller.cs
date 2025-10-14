using UnityEngine;
using UnityEngine.UIElements;

public class enemycontroller : MonoBehaviour
{
    [SerializeField] // bara kolla hur bra min dator är
    bool benchmark = true;

    [SerializeField]
    GameObject boomprefab;
    float speed = 5;
    void Start()
    {
        Vector2 position = new();
        position.x = Random.Range(-11f, 11f);
        position.y = (Camera.main.orthographicSize + 1);

        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector2.down * Time.deltaTime);

        if (benchmark == false)
        {
            if (transform.position.y < Camera.main.orthographicSize - 11)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boomprefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
