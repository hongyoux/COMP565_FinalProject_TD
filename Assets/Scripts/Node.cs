using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color mHoverColor;
    public Vector3 mPosOffset;

    private GameObject mBuilding;

    private Renderer mRend;
    private Color mOriginalColor;

    // Use this for initialization
    void Start () {
        mRend = GetComponent<Renderer>();
        mOriginalColor = mRend.material.color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (mBuilding != null)
        {
            Debug.Log("Something is already here!");
            return;
        }

        GameObject newTurret = BuildManager.instance.GetBuildingToBuild();
        mBuilding = Instantiate(newTurret, transform.position + mPosOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (mBuilding == null)
        {
            mRend.material.color = mHoverColor;
        }
    }

    private void OnMouseExit()
    {
        mRend.material.color = mOriginalColor;
    }
}
