using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyP : Enemy
{
    Vector3 pos = new Vector3(0,0,0);

    protected override void Chase()
    {
        pos = target.position;
        agent.SetDestination(pos);
        Debug.DrawLine(this.transform.position, pos, Color.red);
    }
}
