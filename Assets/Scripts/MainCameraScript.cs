using UnityEngine;

public class MainCameraScript : MonoBehaviour {

    public float mPanSpeed = 20f;
    public float mPanEdge = 10f;
    public Vector2 mPanXLimit;
    public Vector2 mPanZLimit;

    public Vector2 mScrollLimit;

    public float mScrollSpeed = 20f;

	// Update is called once per frame
	void Update () {

        Vector3 newPos = transform.position;

		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - mPanEdge)
        {
            newPos.z += mPanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= mPanEdge)
        {
            newPos.x -= mPanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= mPanEdge)
        {
            newPos.z -= mPanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - mPanEdge)
        {
            newPos.x += mPanSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        newPos.y -= scroll * mScrollSpeed * 100f * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, mPanXLimit.x, mPanXLimit.y);
        newPos.y = Mathf.Clamp(newPos.y, mScrollLimit.x, mScrollLimit.y);
        newPos.z = Mathf.Clamp(newPos.z, mPanZLimit.x, mPanZLimit.y);

        transform.position = newPos;
    }
}
