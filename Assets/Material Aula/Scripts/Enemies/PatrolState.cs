using UnityEngine;

public class PatrolState : CharacterState
{
    [SerializeField] CharacterState nextState;

    private Vector2 _direction = Vector2.right;

    [Header("Movimentação")]
    [SerializeField] private float _speed;

    [Header("Comportamento")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _wallDistance;
    [SerializeField] private float _groundDistance;
    [SerializeField] private Vector2 _positionOffSet;

    [Header("Mudança para o ataque")]
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask _playerLayer;

    public override void EnterState()
    {
        Debug.Log("Entrnado no estao");
    }

    public override void ExitState()
    {
        Debug.Log("Saindo do estado");
    }

    public override void FixedUpdateState()
    {
        Character.rb.linearVelocity = new Vector2(_direction.x * _speed, 0);

        if (!HasFrontGround() || HasFrontWall())
        {
            _speed *= -1;
            _positionOffSet = new Vector2(_positionOffSet.x * -1, _positionOffSet.y);
        }

        CheckPlayer();
    }

    public override void UpdateState()
    {
        //Debug.Log("Executando a lógica");
    }

    private bool HasFrontGround()
    {
        return Physics2D.Raycast((Vector2)transform.position + _positionOffSet, Vector2.down, _groundDistance, _groundLayer);
    }

    private bool HasFrontWall()
    {
        return Physics2D.Raycast((Vector2)transform.position + _positionOffSet, _direction, _wallDistance, _groundLayer);
    }

    private void CheckPlayer()
    {
        if (Physics2D.OverlapBox(transform.position, boxSize, 0, _playerLayer))
        {
            ChangeState(nextState);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // Ground
        Vector2 origin = (Vector2)transform.position + _positionOffSet;
        Vector2 to = origin + (Vector2.down * _groundDistance);
        Gizmos.DrawLine(origin, to);

        // Wall
        // Physics2D.Raycast((Vector2)transform.position + _positionOffSet, _direction, _wallDistance);
        origin = (Vector2)transform.position + _positionOffSet;
        to = origin + (new Vector2(_direction.x * _wallDistance, 0));
        Gizmos.DrawLine(origin, to);

        // caixa de colisão para identificar o player
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
