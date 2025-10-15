using UnityEngine;

public class missilcontroler : MonoBehaviour
{
[SerializeField]
float speed = 9;

    [SerializeField]
    GameObject rödljus;

    void Start()
    {
        
        Vector2 position = new();
        position.x = Random.Range(-11f, 11f);
        position.y = (Camera.main.orthographicSize + 1);
        transform.position = position;

        Instantiate(rödljus, transform.position, Quaternion.identity);
        
    }

    // gör i enemycontroller 
    void Update()
    {
        transform.Translate(speed * Vector2.up * Time.deltaTime);

        
         
    }
}
