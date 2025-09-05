using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class StateMachine
{
    public readonly Dictionary<Type, CharacterState> _states = new Dictionary<Type, CharacterState>();

    public CharacterState CurrentCharacterState { get; private set; }

    public StateMachine(CharacterState initialState, Dictionary<Type, CharacterState> states, Character character)
    {
        CurrentCharacterState = initialState;
        _states = states;
        InitializeStates(character);
    }

    public void ChangeState(CharacterState newState)
    {
        if (_states.ContainsKey(newState.GetType()))
        {
            CurrentCharacterState.ExitState();
            CurrentCharacterState = newState;
            CurrentCharacterState.EnterState();
        }
        else
        {
            Debug.LogError($"State {newState.GetType()} not in states");
        }
    }

    private void InitializeStates(Character character)
    {
        foreach (CharacterState state in _states.Values)
            state.InitializeState(this, character);

        CurrentCharacterState.EnterState();
    }
}

