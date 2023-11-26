using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankDamage : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip dieSound;

    public GameObject expEffect;
    public Image HPBar;
    public Gradient gradient;

    private MeshRenderer[] meshRenderers;

    private int maxHP = 100;
    private int currHP = 0;
    [HideInInspector]
    public bool isDead = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        currHP = maxHP;
        HPBar.color = gradient.Evaluate(HPBar.fillAmount);
        isDead = false;
    }
    public void OnDamage(int damage)
    {
        if(currHP > 0)
        {
            currHP -= damage;
            HPBar.fillAmount = (float)currHP / (float)maxHP;
            HPBar.color = gradient.Evaluate(HPBar.fillAmount);
            OnDamageEffect(Color.blue, 2);
        }
        if(currHP <= 0)
        {
            StartCoroutine(this.Die());
            audio.PlayOneShot(dieSound);
            OnDamageEffect(Color.black, 10);
        }
    }
    public void OnRestoreHealth(int newHealth)
    {
        currHP += newHealth;
        if(currHP >= 100)
        {
            currHP = 100;
        }
        HPBar.fillAmount = (float)currHP / (float)maxHP;
        HPBar.color = gradient.Evaluate(HPBar.fillAmount);
    }
    private IEnumerator Die()
    {
        int layer = gameObject.layer;

        SetTankVisible(false);
        gameObject.layer = 0;
        isDead = true;

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("GameOver");
        //currHP = maxHP;
        //HPBar.fillAmount = (float)currHP / (float)maxHP;
        //HPBar.color = gradient.Evaluate(HPBar.fillAmount);
        //gameObject.layer = layer;
        //isDead = false;
        //SetTankVisible(true);
    }
    private void SetTankVisible(bool visible)
    {
        foreach( MeshRenderer _meshRenderer in meshRenderers)
        {
            _meshRenderer.enabled = visible;
        }
    }
    private void OnDamageEffect(Color color, int scale)
    {
        Vector3 randPosition = new Vector3(Random.Range(0, 0.1f), Random.Range(0, 0.1f), Random.Range(0, 0.1f));
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
    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();
        if(item != null)
        {
            item.Use(gameObject);
        }
    }
}
