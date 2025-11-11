using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UIElements;

public class playercontroller : MonoBehaviour
{
    bool speedBonusPowerUp = false;
    bool killBonusPowerUp = false;
    float speedBonusWaited;
    [SerializeField]
    float powerUpwait = 15f;
    float killBonusWaited;
    [SerializeField]
     float speed = 1f;

    [SerializeField]
     GameObject boltPrefab;

    float timeSInceLastShot = 0;
    [SerializeField]
    float timeBetweenShots = 0.5f;

    [SerializeField]
    GameObject boomprefab;

    [SerializeField]
    float hp = 0;
    [SerializeField]
    float maxhp = 3;

    [SerializeField]
    UnityEngine.UI.Slider hpslider;
    [SerializeField]
    UnityEngine.UI.Slider powerUpSlider1;
    [SerializeField]
    UnityEngine.UI.Slider poweUpSlider2;
    void Start()
    {
        hp = maxhp;
        hpslider.value = hp;
        hpslider.maxValue = maxhp;
        powerUpSlider1.maxValue = powerUpwait;
    }
    void Update()
    {

        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputx + Vector2.up * inputy;
        transform.Translate(movement * 0.02f);

        transform.Translate(movement * speed * Time.deltaTime);
        //skjuta
        timeSInceLastShot += Time.deltaTime;

        hpslider.value = hp;




        if (Input.GetAxisRaw("Fire1") > 0 && timeSInceLastShot > timeBetweenShots)
        {
            AudioSource speaker = GetComponent<AudioSource>();
            speaker.Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSInceLastShot = 0;
        }

        if (killBonusPowerUp)
        {
            killBonusWaited += Time.deltaTime;
            if (killBonusWaited < powerUpwait)
            {
                timeBetweenShots /= 2;
            }
            else if (killBonusWaited > powerUpwait)
            {
                timeBetweenShots *= 2;
                killBonusWaited = 0;
                killBonusPowerUp = false;
            }
        }
        if (speedBonusPowerUp)
        {
            speedBonusWaited += Time.deltaTime;
            if (speedBonusWaited < powerUpwait)
            {
                speed *= 2;
            }
            else if (speedBonusWaited > powerUpwait)
            {
                speed /= 2;
                speedBonusWaited = 0;
                speedBonusPowerUp = false;
            }
        }
        powerUpSlider1.value = killBonusWaited;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "elaking")
        {
            hp -= 1;
            if (hp <= 0)
            {
                SceneManager.LoadScene("Game over");
            }
        }
        else if (collision.gameObject.tag == "killBonusPowerUp")
        {
            if (killBonusPowerUp)
            {
                killBonusWaited -= powerUpwait;
            }
            killBonusPowerUp = true;
        }
        else if (collision.gameObject.tag == "speedBonusPowerUp")
        {
            if (speedBonusPowerUp)
            {
                speedBonusWaited -= powerUpwait;
            }
            speedBonusPowerUp = true;
        }
    }
}
