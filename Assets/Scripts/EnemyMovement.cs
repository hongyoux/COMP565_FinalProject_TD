using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * EnemyMovement
 * -------------
 * Movement Component for basic enemies
 * Provides waypoint functionality to any enemy types
 * Requires an EnemyScript to be present as well
 * Which provides basic stats used here.
 * 
 * Caveat:
 * Script also runs after all other scripts run
 */
[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : MonoBehaviour {

    private EnemyScript mEnemyScript;

    private Transform mNextNode;
    private int mWaypointIndex = 0;

    // Use this for initialization
    void Start () {
        mNextNode = Waypoints.sWaypoints[mWaypointIndex];
        mEnemyScript = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update () {
        Vector3 currDirection = mNextNode.position - transform.position;
        transform.Translate(currDirection.normalized * mEnemyScript.mMoveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, mNextNode.position) < mEnemyScript.mMoveSpeed * Time.deltaTime)
        {
            GetNextWaypoint();
        }

        // Reset move speed after every update so that slows need to get reapplied.
        // TODO: Better debuff system
        mEnemyScript.mMoveSpeed = mEnemyScript.mStartSpeed;
    }

    private void GetNextWaypoint()
    {
        if (mWaypointIndex >= Waypoints.sWaypoints.Length - 1)
        {
            // Reached the last node
            EndPath();
            return;
        }

        mNextNode = Waypoints.sWaypoints[++mWaypointIndex];
    }

    private void EndPath()
    {
        // If enemy reaches end of the waypoints, take away a life from player
        // And destroy the enemy
        PlayerStats.mLivesRemaining--;
        Destroy(gameObject);
    }
}
