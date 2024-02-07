using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : MonoBehaviour
{
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void ChasePlayer(Transform player)
    {
        if (agent != null && player != null)
            agent.SetDestination(player.position);
    }
}
