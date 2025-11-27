using UnityEngine;


public class killBonus : MonoBehaviour
{
    public float powerUpWait = 15;
    public float powerUpWaited = 0;
    public bool killPowerUpActive = false;
    playercontroller player;


    void Update()
    {
        if (killPowerUpActive)
        {
            powerUpWaited += Time.deltaTime;
            if (powerUpWaited > powerUpWait)
            {
                player.timeBetweenShots *= 2;
                killPowerUpActive = false;
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
            killPowerUpActive = true;
            player.timeBetweenShots /= 2;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}