using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Threading;

public class playercontroller : MonoBehaviour
{
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
    float maxhp = 1.5f;

    [SerializeField]
    Slider hpslider; 
    void Start()
    {
        hp = maxhp--;
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
        if (collision.gameObject.tag == "elaking")
        {
            if (hp > 0)
            {
                hp -= 0.5f;
                hpslider.value = hp;
                print((hp + 1) + "HP");
            }
            else
            {
                // Instantiate(boomprefab, transform.position, Quaternion.identity);
                // Destroy(gameObject);
                // print("0 HP");
                // coola grejer
                SceneManager.LoadScene("Game over");
                
            }
        }
    }
}
