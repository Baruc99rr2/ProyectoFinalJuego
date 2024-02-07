using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    PatrolBehavior patrolBehavior;
    ChaseBehavior chaseBehavior;
    AttackBehavior attackBehavior;

    public Transform player1;
    public Transform player2;
    private Transform targetPlayer;

    void Start()
    {
        patrolBehavior = GetComponent<PatrolBehavior>();
        chaseBehavior = GetComponent<ChaseBehavior>();
        attackBehavior = GetComponent<AttackBehavior>();

        player1 = GameObject.Find("CompleteTank")?.transform;
        player2 = GameObject.Find("CompleteTank2")?.transform;

        // Establece el jugador más cercano como objetivo inicial
        if (player1 != null && player2 != null)
        {
            float distanceToPlayer1 = Vector3.Distance(transform.position, player1.position);
            float distanceToPlayer2 = Vector3.Distance(transform.position, player2.position);
            targetPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;
        }
        else if (player1 != null)
        {
            targetPlayer = player1;
        }
        else if (player2 != null)
        {
            targetPlayer = player2;
        }
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // Comprueba si hay cambios en los jugadores más cercanos
        if (player1 != null && player2 != null)
        {
            float distanceToPlayer1 = Vector3.Distance(transform.position, player1.position);
            float distanceToPlayer2 = Vector3.Distance(transform.position, player2.position);
            targetPlayer = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;
        }
        else if (player1 != null)
        {
            targetPlayer = player1;
        }
        else if (player2 != null)
        {
            targetPlayer = player2;
        }

        // Realiza los comportamientos de patrulla, persecución y ataque basándose en el jugador más cercano
        if (!playerInSightRange && !playerInAttackRange)
            patrolBehavior.Patrol();

        if (playerInSightRange && !playerInAttackRange)
            chaseBehavior.ChasePlayer(targetPlayer);

        if (playerInAttackRange && playerInSightRange)
        {
            attackBehavior.AttackPlayer(targetPlayer, transform);
        }
    }
}
