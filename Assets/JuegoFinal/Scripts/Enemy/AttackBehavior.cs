using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public void AttackPlayer(Transform player, Vector3 projectileSpawnPoint)
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
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
