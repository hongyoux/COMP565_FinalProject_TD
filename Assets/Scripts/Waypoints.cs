using UnityEngine;

/**
 * Waypoints
 * ---------
 * Static data class that gets all waypoints on the map in order
 * and converts them into a static list so that enemies can use them
 * to move
 */
public class Waypoints : MonoBehaviour {

    public static Transform[] sWaypoints;

    private void Awake()
    {
        sWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < sWaypoints.Length; i++)
        {
            sWaypoints[i] = transform.GetChild(i);
        }
    }
}
