using UnityEngine;

public class speedBoostController : MonoBehaviour
{

    [SerializeField]
    float powerUpWait = 15;
    float powerUpWaited = 0;
    bool powerUpActive = false;
    playercontroller player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            powerUpWaited += Time.deltaTime;
            if (powerUpWaited > powerUpWait)
            {
                GetComponent<playercontroller>().speed /= 2;
                powerUpActive = false;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.GetComponent<playercontroller>();
            if (player != null)
            {
                powerUpWaited = 0;
                powerUpActive = true;
                player.speed *= 2;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}