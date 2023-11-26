using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [HideInInspector]
    private float speed = 60.0f;
    
    public int damage;
    
    public float attackDelay;

    public GameObject expEffect;

    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;
    private PlayerInput playerInput;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        playerInput = FindObjectOfType<PlayerInput>().GetComponent<PlayerInput>();

        _rigidbody.AddForce(transform.forward * speed);

        // Cannon �߻� ����Ʈ ����. 3�ʵ� �ı�.
        GameObject _eft = (GameObject)Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(_eft, 3.0f);
        // �߻� �ߴ°� ? >> True
        playerInput.isFire = true;
        // �߻� �� 3�ʵ� �ı�.
        StartCoroutine(ExplosionCannon(attackDelay));
    }
    IEnumerator ExplosionCannon(float time)
    {
        if(attackDelay <= 3.0f && attackDelay > 0.0f)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("3�� ���� ����.");
        }
        else
        {
            yield return new WaitForSeconds(3.0f);
            Debug.Log("3�� ��");
        }

        // �浹 ���� off
        //_collider.enabled = false;
        //_rigidbody.isKinematic = true;
        // Cannon ������Ʈ�� ����� ��Ȱ��ȭ.
        //MeshRenderer _renderer = GetComponent<MeshRenderer>();
        //_renderer.enabled = false;
        if(time <= 0.0f)
        {
            yield return new WaitForSeconds(0.0f);
        }
        playerInput.isFire = false;
        Destroy(gameObject, 3.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ��뿡�� TankDamage ��ũ��Ʈ�� �ִٸ�, ������ �ִ� ��ũ��Ʈ ����.
        if (other.GetComponent<EnemyDamage>() != null)
        {
            other.GetComponent<EnemyDamage>().OnDamage(damage);
        }
        // �ε����ٸ� �ٷ� �ı�.
        StartCoroutine(ExplosionCannon(0.0f));
    }
}
