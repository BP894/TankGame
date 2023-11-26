using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTP_Cannon : MonoBehaviour
{
    [HideInInspector]
    private float speed = 60.0f;

    public int damage = 50;

    public float attackDelay = 3.0f;

    public GameObject expEffect;

    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;
    private HTP_PlayerInput playerInput;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        playerInput = FindObjectOfType<HTP_PlayerInput>().GetComponent<HTP_PlayerInput>();

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
        yield return new WaitForSeconds(time);
        // �浹 ���� off
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        // Cannon ������Ʈ�� ����� ��Ȱ��ȭ.
        MeshRenderer _renderer = GetComponent<MeshRenderer>();
        _renderer.enabled = false;
        if (time < attackDelay)
        {
            yield return new WaitForSeconds(attackDelay);
        }
        playerInput.isFire = false;
        Destroy(gameObject, attackDelay);
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
