using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour, IItem
{
    [HideInInspector]
    public int health = 50;

    public void Use(GameObject target)
    {
        TankDamage td = target.GetComponent<TankDamage>();

        if(td != null)
        {
            td.OnRestoreHealth(health);
        }

        Destroy(gameObject);
    }
}
