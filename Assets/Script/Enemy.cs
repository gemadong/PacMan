using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum mode
    {
        Chase,
        Run,
    }
    public mode _Mode = mode.Chase;
    protected NavMeshAgent agent;
    protected Transform target;
    public Player player;
    
    protected virtual void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = this.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        switch (_Mode)
        {
            case mode.Chase:
                Chase();
                break;
            case mode.Run:
                Run();
                break;
            default:
                break;
        }
        playermode();
    }
    protected virtual void Chase()
    {
        agent.SetDestination(target.position);
    }
    void Run()
    {
        agent.SetDestination(-target.position);
    }
    public void Beck()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
    void playermode()
    {
        if (player._Mode == Player.mode.POWER)
        {
            _Mode = mode.Run;
        }
        else if(player._Mode == Player.mode.NORMAL)
        {
            _Mode = mode.Chase;
        }
    }
}
