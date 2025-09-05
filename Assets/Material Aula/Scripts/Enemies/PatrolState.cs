using UnityEngine;

public class PatrolState : CharacterState
{
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
        Debug.Log("Executando a física");

    }

    public override void UpdateState()
    {
        Debug.Log("Executando a lógica");
    }
}
