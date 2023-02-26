using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySM : StateMachine
{
    //[HideInInspector]
    [HideInInspector]
    public Idle st_idle; // IDLE STATE
    [HideInInspector]
    public Chase st_chase; // CHASE STATE
    [HideInInspector]
    public Attack st_attack; // Attack STATE

    public GameObject wp1;
    public GameObject wp2;
    public SpriteRenderer spriteRenderer;

    public void Awake()
    {
        st_idle = new Idle(this);
        st_chase = new Chase(this);
        st_attack = new Attack(this);
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
    public Transform GetTransform()
    {
        return transform;
    }

    protected override BaseState GetInitialState()
    {
        return st_idle;
    }

}