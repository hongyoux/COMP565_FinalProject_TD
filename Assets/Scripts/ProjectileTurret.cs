using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTurret : BasicBuilding {
    [Header("Projectile Parameters")]
    private float mFireTimer = 0f;
    public float mFireRate = 1f;
    public GameObject mBulletPrefab;
	
	// Update is called once per frame
	void Update() {
		if (mCurrentTarget == null)
        {
            return;
        }

        LockOnTarget();

        if (mFireTimer <= 0f)
        {
            ShootBullets();
            mFireTimer = 1f / mFireRate;
        }
        mFireTimer -= Time.deltaTime;
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
}
