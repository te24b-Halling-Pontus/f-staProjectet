using UnityEngine;
using UnityEngine.UI;


public class speedBoostController : MonoBehaviour
{

    [SerializeField]
    float powerUpWait = 15;
    float powerUpWaited = 0;
    public bool speedPowerUpActive = false;
    playercontroller player;
    [SerializeField]
    Slider powerUpSlider1;
    [SerializeField]
    Slider powerUpSlider2;
    bool firstPowerUpActive;
    bool twoPowerUpsActive;
    killBonus killBonus;
    void Start()
    {
        powerUpWaited += Time.deltaTime;
        if (killBonus.killPowerUpActive == true)
        {
            twoPowerUpsActive = true;
        }
        else
        {
            firstPowerUpActive = true;
        }
    }
    void Update()
    {
        if (speedPowerUpActive)
        {
            if (twoPowerUpsActive)
            {
                powerUpSlider2.gameObject.SetActive(true);
                powerUpSlider2.maxValue = powerUpWait;
                powerUpSlider2.value = powerUpWaited;
                if (powerUpWaited > powerUpWait)
                {
                    player.speed /= 2;
                    speedPowerUpActive = false;
                    powerUpSlider2.gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
        else if (twoPowerUpsActive)
        {
            {
                powerUpSlider1.gameObject.SetActive(true);
                powerUpSlider1.maxValue = powerUpWait;
                powerUpSlider1.value = powerUpWaited;
                if (powerUpWaited > powerUpWait)
                {
                    player.speed /= 2;
                    speedPowerUpActive = false;
                    powerUpSlider1.gameObject.SetActive(false);
                    Destroy(gameObject);
                }
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
                speedPowerUpActive = true;
                player.speed *= 2;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;


            }
        }
    }
}