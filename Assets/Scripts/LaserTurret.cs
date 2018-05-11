using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : BasicBuilding {
    [Header("Laser Parameters")]
    public LineRenderer mLaserLineRenderer;
    public int mDOT = 30; // Per Second
    public float mSlowAmount = .5f;
    public ParticleSystem mImpactVfx;
    public Light mImpactLight;
	
	// Update is called once per frame
	void Update() {
		if (mCurrentTarget == null)
        {
            if (mLaserLineRenderer.enabled)
            {
                mLaserLineRenderer.enabled = false;
                mImpactVfx.Stop();
                mImpactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();
        FireLaser();
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
}
