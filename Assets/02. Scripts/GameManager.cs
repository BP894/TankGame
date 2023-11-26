using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cannon cannon = null;
    
    private void Start()
    {
        cannon.damage = 25;
        cannon.attackDelay = 3.0f;
    }
}
