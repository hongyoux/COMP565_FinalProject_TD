using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float mStartSpeed = 10f;
    private float mTotalSlowModifier = 0f;
    [HideInInspector]
    public float mMoveSpeed;

    public float mHealth = 100;
    public int mGoldValue = 50;
    public GameObject mDeathEffect;

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
        PlayerStats.mGold += mGoldValue;
        GameObject deathFX = Instantiate(mDeathEffect, transform.position, Quaternion.identity);

        Destroy(deathFX, 5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update () {

	}

}
