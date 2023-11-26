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

        // Cannon 발사 이펙트 실행. 1초뒤 파괴.
        GameObject _eft = (GameObject)Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(_eft, 3.0f);
        // 발사 후 3초뒤 파괴.
        StartCoroutine(ExplosionCannon(3.0f));
    }
    IEnumerator ExplosionCannon(float time)
    {
        yield return new WaitForSeconds(time);
        // 충돌 판정 off
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        // Cannon 오브젝트의 모습만 비활성화.
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 상대에게 TankDamage 스크립트가 있다면, 데미지 주는 스크립트 실행.
        if (other.GetComponent<TankDamage>() != null)
        {
            other.GetComponent<TankDamage>().OnDamage(damage);
        }
        // 부딪혔다면 바로 파괴.
        StartCoroutine(ExplosionCannon(0.0f));
    }
}
