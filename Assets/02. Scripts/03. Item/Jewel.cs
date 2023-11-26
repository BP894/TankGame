using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour, IItem
{
    [HideInInspector]
    public int power = 20;

    public void Use(GameObject target)
    {
        FireCannon fc = target.GetComponent<FireCannon>();

        if (fc != null)
        {
            fc.cannon.GetComponent<Cannon>().damage += power;
        }
        Debug.Log(fc.cannon.GetComponent<Cannon>().damage);
        Destroy(gameObject);
    }
}
