using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFireCannon : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip fireSound;

    public LayerMask whatIsTarget;
    public GameObject cannon;
    public Transform firePos;

    [HideInInspector]
    public bool isFire = false;
    [HideInInspector]
    public float moveSpeed;

    NavMeshAgent navMeshAgent = null;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveSpeed = navMeshAgent.speed;
    }
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.0f, whatIsTarget);

        foreach(Collider _col in colliders)
        {
            if(_col != null && !isFire && !GetComponent<EnemyMove>().isDead)
            {
                StartCoroutine(Fire());
                break;
            }
        }
    }
    private IEnumerator Fire()
    {
        audio.PlayOneShot(fireSound);
        isFire = true;
        navMeshAgent.speed = 0f;
        Instantiate(cannon, firePos.position, firePos.rotation);

        yield return new WaitForSeconds(3.0f);

        isFire = false;
        navMeshAgent.speed = moveSpeed;
    }
}
