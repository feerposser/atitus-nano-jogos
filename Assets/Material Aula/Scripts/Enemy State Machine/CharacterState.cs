using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class CharacterState : MonoBehaviour
{
    private StateMachine _stateMachine;
    private Character _character;

    public Character Character { get => _character; }
    public StateMachine StateMachine { get => _stateMachine; }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();

    public void InitializeState(StateMachine stateMachine, Character character)
    {
        _stateMachine = stateMachine;
        _character = character;
    }

    public void ChangeState(CharacterState newState)
    {
        _stateMachine.ChangeState(newState);
    }
}
