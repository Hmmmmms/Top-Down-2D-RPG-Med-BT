using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chase : BaseState
{
    private EnemySM _sm;
    public float speed = 0.5f;
    GameObject player;
    public Transform transform;

    public SpriteRenderer spriteRenderer;

    public Chase(EnemySM stateMachine) : base("Chase", stateMachine)
    {
        _sm = (EnemySM)stateMachine;
        transform = stateMachine.GetTransform();
        spriteRenderer = stateMachine.GetSpriteRenderer();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Enter()
    {
        base.Enter();
    }


    //=== OPDATERER LOGIK =====================================================
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 0.6f)
            {
                stateMachine.ChangeState(_sm.st_idle);

            }

            if (Vector2.Distance(transform.position, player.transform.position) < 0.1f)
            {
                stateMachine.ChangeState(_sm.st_attack);

            }


        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        spriteRenderer.material.color = new Color(255f, 85f, 85f, 255f);

        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}