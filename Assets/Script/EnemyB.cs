using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyB : Enemy
{
    public Transform Red;
    Vector3 moveDir = Vector3.zero;


   

    protected override void Chase()
    {
        moveDir = target.position - Red.position;
        agent.SetDestination(moveDir);
        Debug.DrawLine(this.transform.position, moveDir, Color.red);
    }
}
