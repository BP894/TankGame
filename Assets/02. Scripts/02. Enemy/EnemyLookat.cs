using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookat : MonoBehaviour
{
    private PlayerInput targetEntity;

    private void Update()
    {
        targetEntity = GetComponentInParent<EnemyMove>().targetEntity;
        if (targetEntity != null)
        {
            transform.LookAt(targetEntity.transform);
        }
    }
}
