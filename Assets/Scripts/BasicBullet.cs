using UnityEngine;

public class BasicBullet : MonoBehaviour {

    private Transform mTarget;

    public GameObject mHitEffect;
    public float mSpeed = 70f;
    public float mExploRadius = 0f;

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
        transform.LookAt(mTarget);
    }

    private void HitTarget()
    {
        GameObject effectIns = Instantiate(mHitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (mExploRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(mTarget);
        }

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] colliderAoE = Physics.OverlapSphere(transform.position, mExploRadius);
        foreach (Collider c in colliderAoE)
        {
            if (c.tag == "Enemy")
            {
                Damage(c.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, mExploRadius);
    }
}
