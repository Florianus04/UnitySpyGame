using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;   
    public override void Enter()
    {
        
    }
    public override void Exit()
    {

    }
    public override void Perform()
    {
        enemy.anim.SetInteger("Status_walk", 1);
        enemy.anim.SetInteger("status_k98", 2);
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if(shootTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public void Shoot()
    {
        enemy.audio.PlaySoundEffect(enemy.audio.Shoot);
        Transform weaponBarrel = enemy.weaponBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, weaponBarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - weaponBarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * shootDirection * 40f;
        shootTimer = 0;
    }
}
