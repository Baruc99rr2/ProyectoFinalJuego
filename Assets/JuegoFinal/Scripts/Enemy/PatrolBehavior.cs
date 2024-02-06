using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround;
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointSet;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
}
