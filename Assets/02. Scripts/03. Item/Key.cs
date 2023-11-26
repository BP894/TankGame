using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IItem
{
    [HideInInspector]
    public float attackDelay;

    public void Use(GameObject target)
    {
        FireCannon fc = target.GetComponent<FireCannon>();

        if (fc != null)
        {
            // 공격속도 1.5배 상승
            fc.cannon.GetComponent<Cannon>().attackDelay *= 0.67f;
        }

        Debug.Log(fc.cannon.GetComponent<Cannon>().attackDelay);
        Destroy(gameObject);
    }
}
