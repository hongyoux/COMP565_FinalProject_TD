using UnityEngine;

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
