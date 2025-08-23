using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGrounded;
    float x;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] float downDistance;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * horizontalSpeed;
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * verticalSpeed, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        IsGrounded();

        if (!isGrounded )
        {
            x = x / 2;
        }
        rb.linearVelocity = new Vector2(x, rb.linearVelocityY);
    }

    void IsGrounded()
    {
        isGrounded = Physics2D.Raycast(transform.position,
            Vector2.down, downDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector2 to = (Vector2)transform.position + new Vector2(0, downDistance);

        Gizmos.DrawLine(transform.position, to);
    }
}
