using UnityEngine;
using UnityEngine.UIElements;

public class rovLjusController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        Vector2 position = new();
        position.y = (-1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Camera.main.orthographicSize - 11)
            {
                Destroy(gameObject);
            }
    }
}
