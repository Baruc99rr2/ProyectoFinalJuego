using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public void AttackPlayer(Transform targetPlayer, Transform enemyTransform)
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(transform.position);

        transform.LookAt(targetPlayer);

        if (!alreadyAttacked)
        {
            Vector3 projectileSpawnPoint = transform.position + Vector3.up * 2f; // Ajusta la altura según sea necesario
            Rigidbody rb = Instantiate(projectile, projectileSpawnPoint, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 17f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
