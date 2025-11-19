using UnityEngine;

public class killBonus : MonoBehaviour
{
    [SerializeField]
    float powerUpWait = 15;
    float powerUpWaited = 0;
    public bool killPowerUpActive = false;
    playercontroller player;
    [SerializeField]
    UnityEngine.UI.Slider powerUpSlider1;
    [SerializeField]
    UnityEngine.UI.Slider powerUpSlider2;


    // Update is called once per frame
    void Update()
    {
        if (killPowerUpActive)
        {
            // GameObject.Find("speedPowerUpActive").GetComponent<speedBoostController>()
            powerUpWaited += Time.deltaTime;
            if (GameObject.Find("speedPowerUpActive").GetComponent<speedBoostController>() == true)
            {
                powerUpSlider2.gameObject.SetActive(true);
                powerUpSlider2.maxValue = powerUpWait;
                powerUpSlider2.value = powerUpWaited;
                if (powerUpWaited > powerUpWait)
                {
                    player.timeBetweenShots *= 2;
                    killPowerUpActive = false;
                    powerUpSlider2.gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
            else
            {
                powerUpSlider1.gameObject.SetActive(true);
                powerUpSlider1.maxValue = powerUpWait;
                powerUpSlider1.value = powerUpWaited;
                if (powerUpWaited > powerUpWait)
                {
                    player.timeBetweenShots *= 2;
                    killPowerUpActive = false;
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
                killPowerUpActive = true;
                player.timeBetweenShots /= 2;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
