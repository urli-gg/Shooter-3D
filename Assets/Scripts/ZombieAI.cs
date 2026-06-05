using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform target;
    public float speed = 3.5f;

    public float attackDistance = 2f;
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            agent.SetDestination(target.position);

            if (animator != null)
            {
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            agent.SetDestination(transform.position);

            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        PlayerHealth player = target.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
