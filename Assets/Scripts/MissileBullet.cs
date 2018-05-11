using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Missile Bullet
 * --------------
 * Subclass of BasicBullet
 * Includes explosion radius
 * 
 * Overriden method:
 * HitTarget -> Deals damage to all targets near missile on target hit
 * 
 * New Method:
 * OnDrawGizmosSelected() -> Show blast aoe in scene view
 */
public class MissileBullet : BasicBullet {
    [Header("Missile Properties")]
    public float mExplosionRadius = 0f;

    protected override void HitTarget()
    {
        GameObject effectIns = Instantiate(mHitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        // Get all collidables near the missile
        Collider[] colliderAoE = Physics.OverlapSphere(transform.position, mExplosionRadius);
        foreach (Collider c in colliderAoE)
        {
            // If enemy, hurt it
            if (c.tag == "Enemy")
            {
                Damage(c.transform);
            }
        }

        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, mExplosionRadius);
    }
}
