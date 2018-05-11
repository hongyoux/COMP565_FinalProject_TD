using UnityEngine;

/**
 * Base Bullet Class
 * -----------------
 * Contains information about
 * Speed of Projectile
 * Damage of Projectile
 * Missile Target
 * 
 * Virtual Methods:
 * HitTarget
 */
public class BasicBullet : MonoBehaviour {

    [Header("General")]
    public GameObject mHitEffect;
    public float mSpeed = 70f;
    public int mDamage = 5;

    private Transform mTarget;

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }

    protected virtual void HitTarget()
    {
        // Create a hit effect at location and destroy the vfx after 5 seconds
        GameObject effectIns = Instantiate(mHitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        Damage(mTarget);

        Destroy(gameObject);
    }

    protected void Damage(Transform enemy)
    {
        EnemyScript e = enemy.GetComponent<EnemyScript>();
        if (e != null)
        {
            e.TakeDamage(mDamage);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (mTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        // Check if collision would have occured
        Vector3 direction = mTarget.position - transform.position;
        float distTraveledThisFrame = mSpeed * Time.deltaTime;
        if (direction.magnitude <= distTraveledThisFrame)
        {
            // If so, Hit logic
            HitTarget();
            return;
        }

        // Face bullet to target
        transform.Translate(direction.normalized * distTraveledThisFrame, Space.World);
        transform.LookAt(mTarget);
    }
}
