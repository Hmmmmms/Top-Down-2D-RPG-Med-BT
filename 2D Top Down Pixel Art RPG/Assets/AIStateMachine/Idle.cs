using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Idle : BaseState
{
    private EnemySM _sm;

    private GameObject[] waypoint = new GameObject[2];
    // public Transform[] dingo = new Transform[2];
    public float speed = 0.3f;
    GameObject player;
    public Transform transform;
    int currIndex = 0;
    public SpriteRenderer spriteRenderer;


    public Idle(EnemySM stateMachine) : base("Idle", stateMachine)
    {
        //stateMachine = (EnemySM)stateMachine;
        _sm = (EnemySM)stateMachine;

        transform = stateMachine.GetTransform();
        spriteRenderer = stateMachine.GetSpriteRenderer();
        player = GameObject.FindGameObjectWithTag("Player");

        waypoint[0] = _sm.wp1;
        waypoint[1] = _sm.wp2;
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
            if (Vector2.Distance(transform.position, waypoint[currIndex].transform.position) < 0.05f)
            {
                currIndex++;
                if (currIndex >= waypoint.Length)
                {
                    currIndex = 0;
                }
            }

            if (Vector2.Distance(transform.position, player.transform.position) < 0.6f)
            {
                stateMachine.ChangeState(_sm.st_chase);

            }
            
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        spriteRenderer.material.color = new Color(255f, 85f, 85f, 255f);
        if (currIndex < waypoint.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint[currIndex].transform.position, speed * Time.deltaTime);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}