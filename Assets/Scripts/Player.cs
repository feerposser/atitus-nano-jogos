using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;
    float x;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] float downDistance;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("xSpeed", Mathf.Abs(x));
        anim.SetFloat("ySpeed", rb.linearVelocityY);
        anim.SetBool("isGrounded", isGrounded);

        x = Input.GetAxis("Horizontal") * horizontalSpeed;

        if (x > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (x < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);



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
    }
}
