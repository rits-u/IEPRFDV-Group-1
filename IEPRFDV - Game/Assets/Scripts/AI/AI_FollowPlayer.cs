using UnityEngine;
using UnityEngine.AI;

public class AI_FollowPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Transform target;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.8f;
    //[SerializeField] private bool randomMovement = false;
    //[SerializeField] private float randomDistUntil = 5.0f;


    [Header("Attack")]
    [SerializeField] private float attackDistance;
    [SerializeField] private bool stopOnAttack = false;
    //[SerializeField] private float cooldown;
    
    private Vector3 positionOffset;
    private NavMeshAgent navAgent;
    //private Animator animator;
    private float targetDistance;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();

        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;

        navAgent.speed = moveSpeed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player.transform.position + positionOffset;
        targetDistance = Vector3.Distance(navAgent.transform.position, target.position);
        if (targetDistance < attackDistance)
        {
            //if (stopOnAttack)
            //{
            //    navAgent.isStopped = true;
            //    animator.SetBool("Attack, true");
            //}
        }
        else
        {
            //if (stopOnAttack)
            //{
            //    navAgent.isStopped = false;
            //    animator.SetBool("Attack, false");
            //}
            navAgent.SetDestination(target.position);
            
        }
    }

    //private void OnAnimatorMove()
    //{
    //    if (animator.GetBool("Attack") == false)
    //    {
    //        navAgent.speed = (animator.deltaPosition / Time.deltaTime).magnitude;
    //    }
    //}
}

/*
 public class RandomWalk : MonoBehaviour
    {
        public float m_Range = 25.0f;
        NavMeshAgent m_Agent;

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
                return;

            m_Agent.destination = m_Range * Random.insideUnitCircle;
        }
    }
 */

