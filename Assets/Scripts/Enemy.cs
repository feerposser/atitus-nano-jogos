using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 _direction = Vector2.right;

    [Header("Movimentação")]
    [SerializeField] private float _speed;

    [Header("Comportamento")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _wallDistance;
    [SerializeField] private float _groundDistance;
    [SerializeField] private Vector2 _positionOffSet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_direction.x * _speed, 0);

        if (!HasFrontGround() || HasFrontWall())
        {
            _speed *= -1;
            _positionOffSet = new Vector2(_positionOffSet.x * -1, _positionOffSet.y);
        }
    }

    private bool HasFrontGround()
    {
        return Physics2D.Raycast((Vector2)transform.position + _positionOffSet, Vector2.down, _groundDistance, _groundLayer);
    }

    private bool HasFrontWall()
    {
        return Physics2D.Raycast((Vector2)transform.position + _positionOffSet, _direction, _wallDistance, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 origin = (Vector2)transform.position + _positionOffSet;
        Vector2 to = origin + (Vector2.down * _groundDistance);
        Gizmos.DrawLine(origin, to);
    }

}
