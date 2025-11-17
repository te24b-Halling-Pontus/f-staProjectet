using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UIElements;

public class playercontroller : MonoBehaviour
{
    public bool speedBonusPowerUp = false;
    public bool killBonusPowerUp = false;
    public float speedBonusWaited;
    [SerializeField]
    float powerUpwait = 15f;
    public float killBonusWaited;
    [SerializeField]
    public float speed = 1f;

    [SerializeField]
    GameObject boltPrefab;

    float timeSInceLastShot = 0;
    [SerializeField]
    public float timeBetweenShots = 0.5f;

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
        powerUpSlider1.gameObject.SetActive(false);
    }
    void Update()
    {

        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputx + Vector2.up * inputy;
        transform.Translate(movement * 0.02f);

        transform.Translate(movement * speed * Time.deltaTime);

        hpslider.value = hp;
        powerUpSlider1.value = killBonusWaited;
        timeSInceLastShot += Time.deltaTime;


        //skjuta
        if (Input.GetAxisRaw("Fire1") > 0 && timeSInceLastShot > timeBetweenShots)
        {
            AudioSource speaker = GetComponent<AudioSource>();
            speaker.Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSInceLastShot = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 1;
            if (hp <= 0)
            {
                SceneManager.LoadScene("Game over");
            }
        }
    }
}
