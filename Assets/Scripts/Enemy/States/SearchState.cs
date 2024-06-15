using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnowPos);
    }
    public override void Perform()
    {
        enemy.anim.SetInteger("Status_walk", 1);
        enemy.anim.SetInteger("status_k98", 1);
        if (enemy.CanSeePlayer())
            stateMachine.ChangeState(new AttackState());
        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 5))
            {
                Debug.Log("ara");
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            if (searchTimer > 10)
            {
                Debug.Log("devriyeye dön");
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public override void Exit()
    {

    }
}
