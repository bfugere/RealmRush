using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float towerRange = 15f;
    
    Transform target;

    void Update()
    {
        if (FindObjectOfType<Enemy>() != null)
        {
            FindClosestTarget();
            AimWeapon();
        }
        else
            Attack(false);
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < towerRange)
        {
            weapon.LookAt(target);
            Attack(true);
        }
        else
            Attack(false);
    }

    void Attack(bool isEnemyPresent)
    {
        var emissionModule = GetComponentInChildren<ParticleSystem>().emission;
        emissionModule.enabled = isEnemyPresent;
    }
}
