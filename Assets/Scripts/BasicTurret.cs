using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour {

    //TODO: Add a logic system for which target to pick.
    private Transform mCurrentTarget;
    private float mFireTimer = 0f;

    [Header("Attributes")]
    public float mRange = 10f;
    public float mTurnSpeed = 10f;
    public float mFireRate = 1f;

    [Header("Unity Setup Vars")]
    public Transform mHeadRotatePoint;
    public string mEnemyTag = "Enemy";
    public GameObject mBulletPrefab;
    public Transform mBulletSpawnPoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0, .25f);
	}
	
	// Update is called once per frame
	void Update() {
		if (mCurrentTarget == null)
        {
            return;
        }

        Vector3 direction = mCurrentTarget.position - transform.position;
        Quaternion dirQuat = Quaternion.LookRotation(direction);

        Vector3 lookRotation = Quaternion.Lerp(mHeadRotatePoint.rotation, dirQuat, Time.deltaTime * mTurnSpeed).eulerAngles;
        mHeadRotatePoint.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);

        if (mFireTimer <= 0f)
        {
            ShootBullets();
            mFireTimer = 1f / mFireRate;
        }

        mFireTimer -= Time.deltaTime;

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
        }
        else
        {
            mCurrentTarget = null;
        }
    }

    private void ShootBullets()
    {
        GameObject newBullet = Instantiate(mBulletPrefab, mBulletSpawnPoint.position, mBulletSpawnPoint.rotation);
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
