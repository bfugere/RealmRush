using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    
    Transform target;

    void Start()
    {
        try
        {
            target = FindObjectOfType<EnemyMover>().transform;
        }

        catch (NullReferenceException)
        {
            Debug.Log("No enemy present..");
        }
    }

    void Update()
    {
        if (target != null)
            AimWeapon();
        else
            Attack(false);
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }

    void Attack(bool isEnemyPresent)
    {
        var emissionModule = GetComponentInChildren<ParticleSystem>().emission;
        emissionModule.enabled = isEnemyPresent;
    }
}
