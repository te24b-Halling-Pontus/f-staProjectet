using UnityEngine;

public class jumpercontroller : MonoBehaviour
{
    [SerializeField]
    float jumpforce = 100f;
    [SerializeField]
    float speed = 7;

    [SerializeField]
    GameObject groundChecker;

    [SerializeField]
    LayerMask groundLayer;

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(
            groundChecker.transform.position,
            0.3f,
            groundLayer
        );
        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
    void Update()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        Vector2 movement = Vector2.right * inputx;
        transform.Translate(movement * Time.deltaTime * speed);
    }
}
