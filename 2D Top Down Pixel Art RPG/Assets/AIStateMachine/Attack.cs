using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack : BaseState
{
    private EnemySM _sm;
  
    public float speed = 0.5f;
    GameObject player;
    public Transform transform;

    public SpriteRenderer spriteRenderer;


    public Attack(EnemySM stateMachine) : base("Attack", stateMachine)
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
            if (Vector2.Distance(transform.position, player.transform.position) > 0.1f)
            {
                stateMachine.ChangeState(_sm.st_chase);

            }
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        spriteRenderer.material.color = new Color(255f, 0.0f, 0.0f, 255f);


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