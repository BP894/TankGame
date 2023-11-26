using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTank_Cannon : MonoBehaviour
{
    [HideInInspector]
    private float speed = 60.0f;
    private int damage = 20;

    public GameObject expEffect;

    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;

    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * speed);

        // Cannon �߻� ����Ʈ ����. 1�ʵ� �ı�.
        GameObject _eft = (GameObject)Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(_eft, 3.0f);
        // �߻� �� 3�ʵ� �ı�.
        StartCoroutine(ExplosionCannon(3.0f));
    }
    IEnumerator ExplosionCannon(float time)
    {
        yield return new WaitForSeconds(time);
        // �浹 ���� off
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        // Cannon ������Ʈ�� ����� ��Ȱ��ȭ.
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ��뿡�� TankDamage ��ũ��Ʈ�� �ִٸ�, ������ �ִ� ��ũ��Ʈ ����.
        if (other.GetComponent<TankDamage>() != null)
        {
            other.GetComponent<TankDamage>().OnDamage(damage);
        }
        // �ε����ٸ� �ٷ� �ı�.
        StartCoroutine(ExplosionCannon(0.0f));
    }
}
