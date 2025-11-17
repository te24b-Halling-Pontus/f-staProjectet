using UnityEngine;

public class missilcontroler : MonoBehaviour
{
    [SerializeField]
    GameObject boomPrefab;
    [SerializeField]
    float speed = 9;
    [SerializeField]
    GameObject KillBonusPreFab;
    [SerializeField]
    GameObject speedBonusPreFab;
    int witchPowerUp;

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
        witchPowerUp = Random.Range(1, 21);
        if (witchPowerUp == 6)
        {
            Instantiate(speedBonusPreFab, transform.position, Quaternion.identity);
        }
        else if (witchPowerUp == 7)
        {
            Instantiate(KillBonusPreFab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
