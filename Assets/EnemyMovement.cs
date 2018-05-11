using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        mEnemyScript.mMoveSpeed = mEnemyScript.mStartSpeed;
    }

    private void GetNextWaypoint()
    {
        // Reached the last node, destroy self.
        // TODO: Inflict lifepoint loss or something.
        if (mWaypointIndex >= Waypoints.sWaypoints.Length - 1)
        {
            EndPath();
            return;
        }

        mNextNode = Waypoints.sWaypoints[++mWaypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.mLivesRemaining--;
        Destroy(gameObject);
    }
}
