using UnityEngine;

/**
 * Enemy Script
 * ------------
 * Contains base AI functionality for enemy types
 */
public class EnemyScript : MonoBehaviour {

    [Header("Stats")]
    public float mStartSpeed = 10f;
    public float mHealth = 100;
    public int mGoldValue = 50;

    [Header("VFX")]
    public GameObject mDeathEffect;

    [HideInInspector]
    public float mMoveSpeed;

    private void Start()
    {
        mMoveSpeed = mStartSpeed;
    }

    public void TakeDamage(float damageDealt)
    {
        mHealth -= damageDealt;
        if (mHealth <= 0)
        {
            Die();
        }
    }

    public void Slow(float slowPercent)
    {
        mMoveSpeed = mStartSpeed * (1 - slowPercent);
    }

    private void Die()
    {
        // Play death effect, give player more gold, then destroy self
        PlayerStats.mGold += mGoldValue;

        GameObject deathFX = Instantiate(mDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathFX, 5f);

        Destroy(gameObject);
    }
}
