using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public LayerMask whatIsTarget;
    public GameObject F_WheelLeft;
    public GameObject F_WheelRight;
    public GameObject B_WheelLeft;
    public GameObject B_WheelRight;

    [HideInInspector]
    public PlayerInput targetEntity;

    private NavMeshAgent pathFinder;
    private EnemyFireCannon enemyFireCannon;

    public bool isDead = false;
    private bool hasTarget
    {
        get
        {
            if (targetEntity != null)
            {
                return true;
            }
            return false;
        }
    }
    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        enemyFireCannon = GetComponent<EnemyFireCannon>();
        isDead = false;
    }
    private void Start()
    {
        StartCoroutine(UpdatePath());
    }
    private IEnumerator UpdatePath()
    {
        while (!isDead)
        {
            if (hasTarget)
            {
                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);
            }
            else
            {
                pathFinder.isStopped = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, 40f, whatIsTarget);
                foreach (Collider _col in colliders)
                {
                    PlayerInput _targetEntity = _col.GetComponent<PlayerInput>();
                    if (_targetEntity != null)
                    {
                        targetEntity = _targetEntity;
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
    private void Update()
    {
        F_WheelLeft.transform.Rotate(Vector3.right * pathFinder.speed * Time.deltaTime * 500);
        F_WheelRight.transform.Rotate(Vector3.right * pathFinder.speed * Time.deltaTime * 500);
        B_WheelLeft.transform.Rotate(Vector3.right * pathFinder.speed * Time.deltaTime * 500);
        B_WheelRight.transform.Rotate(Vector3.right * pathFinder.speed * Time.deltaTime * 500);
    }
}
