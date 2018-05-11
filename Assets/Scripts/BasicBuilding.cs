using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * BasicBuilding
 * -------------
 * Base class for buildings
 * Includes things like range
 * and target acquisition
 */
public class BasicBuilding : MonoBehaviour {

    [Header("General")]
    public float mRange = 10f;
    public float mTurnSpeed = 10f;
    public Transform mHeadRotatePoint;
    public string mEnemyTag = "Enemy";
    public Transform mSpawnPoint;

    protected Transform mCurrentTarget;
    protected EnemyScript mCurrentTargetScript;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, .25f);
    }

    protected void LockOnTarget()
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, mRange);
    }
}
