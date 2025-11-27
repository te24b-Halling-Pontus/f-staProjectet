using UnityEngine;



public class speedBoostController : MonoBehaviour
{
    public float powerUpWait = 15;
    public float powerUpWaited = 0;
    public bool speedPowerUpActive = false;
    playercontroller player;
    void Update()
    {
        if (speedPowerUpActive)
        {
            powerUpWaited += Time.deltaTime;
            if (powerUpWaited > powerUpWait)
            {
                player.speed /= 2;
                speedPowerUpActive = false;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.GetComponent<playercontroller>();
            powerUpWaited = 0;
            speedPowerUpActive = true;
            player.speed *= 2;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}