using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    PatrolBehavior patrolBehavior;
    ChaseBehavior chaseBehavior;
    AttackBehavior attackBehavior;

    void Start()
    {
        patrolBehavior = GetComponent<PatrolBehavior>();
        chaseBehavior = GetComponent<ChaseBehavior>();
        attackBehavior = GetComponent<AttackBehavior>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
            patrolBehavior.Patrol();

        if (playerInSightRange && !playerInAttackRange)
            chaseBehavior.ChasePlayer();

        if (playerInAttackRange && playerInSightRange)
        {
            Vector3 projectileSpawnPoint = transform.position + Vector3.up * 2f;
            attackBehavior.AttackPlayer(GameObject.Find("CompleteTank").transform, projectileSpawnPoint);
        }
    }
}
