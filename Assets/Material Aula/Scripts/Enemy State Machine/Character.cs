using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private StateMachine _stateMachine = null;

    [NonSerialized] public Rigidbody2D rb;
    [NonSerialized] public Animator animator;

    [Header("Base configuration")]
    [SerializeField]
    private CharacterState initialState = null;

    public StateMachine StateMachine { get; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Dictionary<Type, CharacterState> states = new Dictionary<Type, CharacterState>();

        CharacterState[] availableStates = GetComponents<CharacterState>();

        foreach (CharacterState availableState in availableStates)
        {
            if (!states.ContainsKey(availableState.GetType()))
                states.Add(availableState.GetType(), availableState);
            else
                Debug.LogWarning($"{availableState.GetType()} is duplicated. Not included.");
        }
        _stateMachine = new StateMachine(initialState, states, this);
    }

    void Update()
    {
        _stateMachine.CurrentCharacterState.UpdateState();
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentCharacterState.FixedUpdateState();
    }
}
