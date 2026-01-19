using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

public class AI_FollowPlayer : MonoBehaviour
{

    [Header("References")]
    [SerializeField] public Transform target;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.8f;
    //[SerializeField] private bool randomMovement = false;
    [SerializeField] private bool hasLimitedVisibility = false;
    [ShowIf("hasLimitedVisibility")][SerializeField] private float detectionRadius = 5.0f;
    //[ShowIf("randomMovement")][SerializeField] private float randomMovementRange = 5.0f;


    [Header("Attack")]
    [SerializeField] private float attackDistance;
    [SerializeField] private bool stopOnAttack = false;
    //[SerializeField] private float cooldown;
    
    private Vector3 positionOffset;
    private NavMeshAgent navAgent;
    //private Animator animator;
    //private float detectionBuffer = 1.0f;
    private float targetDistance;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();

        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;
        navAgent.speed = moveSpeed;

        //if (attackDistance < detectionRadius)
        //{
        //    detectionRadius = attackDistance + 3.0f;
        //}


        SetRotation();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetDistance = Vector3.Distance(navAgent.transform.position, target.position);
        SetRotation();

        if (!hasLimitedVisibility)
        {
            navAgent.SetDestination(target.position);
        }
        else if (targetDistance <= detectionRadius)
        {
            if (targetDistance <= attackDistance)
            {
                //if (stopOnAttack)
                //{
                //    navAgent.isStopped = true;
                //    animator.SetBool("Attack", true);
                //}
            }
            else
            {
                //if (stopOnAttack)
                //{
                //    navAgent.isStopped = false;
                //    animator.SetBool("Attack", false);
                //}
                navAgent.SetDestination(target.position);

            }   
        }
        //else if (randomMovementRange && targetDistance > detectionRadius + detectionBuffer)
        //{
        //    //Prevents auto braking from stopping random movement
        //    if (navAgent.remainingDistance > navAgent.stoppingDistance)
        //    {
                
        //    }
        //    else
        //    {
        //        Vector2 randomOffset = Random.insideUnitCircle * randomMovementRange;
        //        Vector3 randomDest = navAgent.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
        //        navAgent.SetDestination(randomDest);
        //    }
        //}
    }

    private void SetRotation()
    {
        Vector3 direction = target.position - navAgent.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;
        navAgent.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    //private void OnAnimatorMove()
    //{
    //    if (animator.GetBool("Attack") == false)
    //    {
    //        navAgent.speed = (animator.deltaPosition / Time.deltaTime).magnitude;
    //    }
    //}
}


