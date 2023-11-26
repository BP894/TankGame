using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip dieSound;

    public GameObject expEffect;
    public Image HPBar;
    private MeshRenderer[] meshRenderers;

    private int maxHP = 100;
    private int currHP = 0;
    [HideInInspector]
    public event Action onDeath;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        currHP = maxHP;
    }
    public void OnDamage(int damage)
    {
        if (currHP > 0)
        {
            currHP -= damage;
            HPBar.fillAmount = (float)currHP / (float)maxHP;
            OnDamageEffect(Color.red, 2);
        }
        if (currHP <= 0)
        {
            StartCoroutine(this.Die());
            audio.PlayOneShot(dieSound);
            OnDamageEffect(Color.red, 10);
        }
        
    }
    private IEnumerator Die()
    {
        int layer = gameObject.layer;

        SetTankVisible(false);
        GetComponent<EnemyMove>().isDead = true;
        GetComponent<BoxCollider>().enabled = false;
        gameObject.layer = 0;
        ItemSpawner_Death.instance.Spawn(transform.position);

        yield return new WaitForSeconds(3.0f);

        if(onDeath != null)
        {
            onDeath();
        }
    }
    private void SetTankVisible(bool visible)
    {
        foreach (MeshRenderer _meshRenderer in meshRenderers)
        {
            _meshRenderer.enabled = visible;
        }
        GetComponentInChildren<Canvas>().enabled = visible;
    }
    private void OnDamageEffect(Color color, int scale)
    {
        Vector3 randPosition = new Vector3(UnityEngine.Random.Range(0, 0.1f), UnityEngine.Random.Range(0, 0.1f), UnityEngine.Random.Range(0, 0.1f));
        GameObject _obj = (GameObject)Instantiate(expEffect, transform.position + randPosition, transform.rotation);
        _obj.transform.localScale *= scale;
        _obj.transform.SetParent(transform);
        ParticleSystem[] ps = _obj.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem _ps in ps)
        {
            ParticleSystem.MainModule _pm = _ps.main;
            _pm.startColor = color;
        }
        Destroy(_obj, 3.0f);
    }
    public void SetUp(float newHealth, float newSpeed, float newScale, Color newColor)
    {
        maxHP = (int)newHealth;
        currHP = (int)newHealth;
        GetComponent<NavMeshAgent>().speed *= newSpeed;
        this.gameObject.transform.localScale 
            = new Vector3(0.2f * newScale, 0.2f * newScale, 0.2f * newScale);
        foreach(MeshRenderer _meshRenderer in meshRenderers)
        {
            _meshRenderer.material.color = newColor;
        }
    }
}
