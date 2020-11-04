using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCenter : MonoBehaviour
{
    public double GRVT = 6.67 * 0.00000000001f;
    public float mass = 1f;

    public float distanceValue = 1f;

    private void FixedUpdate()
    {
        ApplyForceToObjects();
    }

    private void ApplyForceToObjects()
    {
        if (Projectile.projectiles != null)
        {
            for(int i = 0; i < Projectile.projectiles.Count; i++)
            {
                Projectile.projectiles[i].AddForce(GetNormalGravityForce(Projectile.projectiles[i].Mass, Projectile.projectiles[i].Pos));
            }
        }
            
    }

    private Vector3 GetNormalGravityForce(float m, Vector3 pos)
    {
        Vector3 direction = (transform.position - pos).normalized;
        float r = Vector3.Distance(transform.position, pos);

        return direction * ((float)GRVT * (mass * m) / r * r * distanceValue);
    }
}
