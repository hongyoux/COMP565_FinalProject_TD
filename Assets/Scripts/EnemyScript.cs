using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float mMoveSpeed = 10f;

    private Transform mNextNode;
    private int mWaypointIndex = 0;

	// Use this for initialization
	private void Start () {
        mNextNode = Waypoints.sWaypoints[mWaypointIndex];
	}
	
	// Update is called once per frame
	private void Update () {
        Vector3 currDirection = mNextNode.position - transform.position;
        transform.Translate(currDirection.normalized * mMoveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, mNextNode.position) < mMoveSpeed * Time.deltaTime)
        {
            GetNextWaypoint();
        }
	}

    private void GetNextWaypoint()
    {
        // Reached the last node, destroy self.
        // TODO: Inflict lifepoint loss or something.
        if (mWaypointIndex >= Waypoints.sWaypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        mNextNode = Waypoints.sWaypoints[++mWaypointIndex];
    }
}
