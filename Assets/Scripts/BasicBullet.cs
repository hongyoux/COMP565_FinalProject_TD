using UnityEngine;

public class BasicBullet : MonoBehaviour {

    private Transform mTarget;

    public GameObject mHitEffect;
    public float mSpeed = 70f;

    public void SetTarget(Transform target)
    {
        mTarget = target;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = mTarget.position - transform.position;

        float distTraveledThisFrame = mSpeed * Time.deltaTime;

        if (direction.magnitude <= distTraveledThisFrame)
        {
            // Hit Logic
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distTraveledThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effectIns = Instantiate(mHitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(mTarget.gameObject);
        Destroy(gameObject);
        return;
    }
}
