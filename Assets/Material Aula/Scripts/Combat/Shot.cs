using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    /*[System.NonSerialized] */public Vector2 direction;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(gameObject, 5);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("impact");
        rb.linearVelocity = Vector2.zero;
    }
}
