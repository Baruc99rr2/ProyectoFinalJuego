using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("CompleteTank").transform;
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
