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

        // Cannon 발사 이펙트 실행. 3초뒤 파괴.
        GameObject _eft = (GameObject)Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(_eft, 3.0f);
        // 발사 했는가 ? >> True
        playerInput.isFire = true;
        // 발사 후 3초뒤 파괴.
        StartCoroutine(ExplosionCannon(attackDelay));
    }
    IEnumerator ExplosionCannon(float time)
    {
        yield return new WaitForSeconds(time);
        // 충돌 판정 off
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        // Cannon 오브젝트의 모습만 비활성화.
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
        // 부딪힌 상대에게 TankDamage 스크립트가 있다면, 데미지 주는 스크립트 실행.
        if (other.GetComponent<EnemyDamage>() != null)
        {
            other.GetComponent<EnemyDamage>().OnDamage(damage);
        }
        // 부딪혔다면 바로 파괴.
        StartCoroutine(ExplosionCannon(0.0f));
    }
}
