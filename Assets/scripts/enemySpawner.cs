using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField]
    float wait = 0.5f;
    float waited = 0;
    [SerializeField]
    GameObject redLightPreFab;

    [SerializeField]
    GameObject enemyPrefab;
    int whatToSpawn;
    [SerializeField]
    Slider powerUpSlider1;
    [SerializeField]
    Slider powerUpSlider2;

    killBonus killBonus;

    speedBoostController speedBoost;

    void Start()
    {
        killBonus = GameObject.Find("killBonus").GetComponent<killBonus>(); 
        speedBoost = GameObject.Find("speedBoost").GetComponent<speedBoostController>();
    }
    void Update()
    {
        waited += Time.deltaTime;
        if (wait < waited)
        {
            whatToSpawn = Random.Range(1, 11);
            waited = 0;
            if (whatToSpawn < 7)
            {
                Instantiate(enemyPrefab);
            }
            else if (whatToSpawn >= 7)
            {
                Instantiate(redLightPreFab);
            }
        }
        
        // powerUpSlider1.gameObject.SetActive(killBonus.killPowerUpActive || speedBoost.speedPowerUpActive);
        // powerUpSlider2.gameObject.SetActive(killBonus.killPowerUpActive && speedBoost.speedPowerUpActive);
        if (killBonus.killPowerUpActive)
        {
            powerUpSlider1.maxValue = killBonus.powerUpWait;
            powerUpSlider1.value = killBonus.powerUpWaited;
            if (speedBoost.speedPowerUpActive)
            {
                powerUpSlider2.maxValue = speedBoost.powerUpWait;
                powerUpSlider2.value = speedBoost.powerUpWaited;
            }
        }
        else if (speedBoost.speedPowerUpActive)
        {
            powerUpSlider1.maxValue = speedBoost.powerUpWait;
            powerUpSlider1.value = speedBoost.powerUpWaited;
        }
    }
}

