using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class playercontroller : MonoBehaviour
{
    public float speed = 1f;

    [SerializeField]
    GameObject boltPrefab;

    float timeSInceLastShot = 0;

    [SerializeField]
    GameObject boomprefab;

    float hp = 3;
    [SerializeField]
    float maxhp = 3;

    [SerializeField]
    Slider hpslider;
    public float timeBetweenShots = 0.5f;



    void Start()
    {
        hp = maxhp;
        hpslider.maxValue = maxhp;
        hpslider.value = hp;
    }
    void Update()
    {

        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputx + Vector2.up * inputy;
        transform.Translate(movement * 0.02f);

        transform.Translate(movement * speed * Time.deltaTime);

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
            hpslider.value = hp;
            if (hp <= 0)
            {
                SceneManager.LoadScene("Game over");
            }
        }
    }
}