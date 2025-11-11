using UnityEngine;

public class missilcontroler : MonoBehaviour
{
    [SerializeField]
    GameObject boomPrefab;

    [SerializeField]
    float speed = 9;

    [SerializeField]
    float waittime = 5;
    [SerializeField]
    float waited = 0;

    void Start()
    {
        
    }

    // gör i enemycontroller 
    void Update()
    {
        transform.Translate(speed * Vector2.down * Time.deltaTime);

        if (transform.position.y < Camera.main.orthographicSize - 11)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
