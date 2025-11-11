using UnityEngine;
using UnityEngine.UIElements;

public class rovLjusController : MonoBehaviour
{
    float waited = 0f;
    [SerializeField]
    float wait = 1.1f;
    [SerializeField]
    GameObject missilPrefab;
    [SerializeField]
    float waitdestroy = 5;
    float waitedDestroy = 0f;

    bool synlig = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 position = new();
        position.x = UnityEngine.Random.Range(-10.5f, 10.5f);
        position.y = (Camera.main.orthographicSize - 0.3f);
        transform.position = position;
        
    }

    // Update is called once per frame
    void Update()
    {
        waited        += Time.deltaTime;
        waitedDestroy += Time.deltaTime;

        if (waited > wait)
        {
            synlig = !synlig;
            waited = 0;
            GetComponent<SpriteRenderer>().enabled = synlig;
        }


        if (waitedDestroy > waitdestroy)
        {
            Instantiate(missilPrefab, transform.position + Vector3.down * -1.3f, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
