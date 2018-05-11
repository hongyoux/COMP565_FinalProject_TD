using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour {

    private Transform mCurrentTarget;
    private EnemyScript mCurrentTargetScript;

    [Header("General")]
    public float mRange = 10f;

    [Header("Use Bullets(default)")]
    private float mFireTimer = 0f;
    public float mFireRate = 1f;
    public GameObject mBulletPrefab;

    [Header("Use Laser")]
    public bool mUseLaser = false;
    public LineRenderer mLaserLineRenderer;
    public int mDOT = 30; // Per Second
    public float mSlowAmount = .5f;

    [Header("Unity Setup Vars")]
    public float mTurnSpeed = 10f;
    public Transform mHeadRotatePoint;
    public string mEnemyTag = "Enemy";
    public Transform mSpawnPoint;
    public ParticleSystem mImpactVfx;
    public Light mImpactLight;

    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0, .25f);
	}
	
	// Update is called once per frame
	void Update() {
		if (mCurrentTarget == null)
        {
            if (mUseLaser)
            {
                if (mLaserLineRenderer.enabled)
                {
                    mLaserLineRenderer.enabled = false;
                    mImpactVfx.Stop();
                    mImpactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (mUseLaser)
        {
            FireLaser();
        }
        else
        {
            if (mFireTimer <= 0f)
            {
                ShootBullets();
                mFireTimer = 1f / mFireRate;
            }

            mFireTimer -= Time.deltaTime;
        }
    }

    private void LockOnTarget()
    {
        //Lock onto Target
        Vector3 direction = mCurrentTarget.position - transform.position;
        Quaternion dirQuat = Quaternion.LookRotation(direction);

        Vector3 lookRotation = Quaternion.Lerp(mHeadRotatePoint.rotation, dirQuat, Time.deltaTime * mTurnSpeed).eulerAngles;
        mHeadRotatePoint.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(mEnemyTag);
        float closestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
            if (distToEnemy < closestDistance)
            {
                closestDistance = distToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (closestDistance < mRange && nearestEnemy != null)
        {
            mCurrentTarget = nearestEnemy.transform;
            mCurrentTargetScript = mCurrentTarget.GetComponent<EnemyScript>();
        }
        else
        {
            mCurrentTarget = null;
            mCurrentTargetScript = null;
        }
    }

    private void FireLaser()
    {
        mCurrentTargetScript.TakeDamage(mDOT * Time.deltaTime);
        mCurrentTargetScript.Slow(mSlowAmount);

        if (!mLaserLineRenderer.enabled)
        {
            mLaserLineRenderer.enabled = true;
            mImpactVfx.Play();
            mImpactLight.enabled = true;
        }

        mLaserLineRenderer.SetPosition(0, mSpawnPoint.position);
        mLaserLineRenderer.SetPosition(1, mCurrentTarget.position);

        Vector3 dir = mSpawnPoint.position - mCurrentTarget.position;

        mImpactVfx.transform.rotation = Quaternion.LookRotation(dir);

        mImpactVfx.transform.position = mCurrentTarget.position + dir.normalized;
    }

    private void ShootBullets()
    {
        GameObject newBullet = Instantiate(mBulletPrefab, mSpawnPoint.position, mSpawnPoint.rotation);
        BasicBullet bullet = newBullet.GetComponent<BasicBullet>();

        if (bullet != null)
        {
            bullet.SetTarget(mCurrentTarget);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, mRange);
    }
}
