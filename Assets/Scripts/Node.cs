using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color mHoverColor;
    public Vector3 mPosOffset;

    private BuildManager mBuildManager;
    private GameObject mBuilding;

    private Renderer mRend;
    private Color mOriginalColor;


    // Use this for initialization
    void Start () {
        mRend = GetComponent<Renderer>();
        mOriginalColor = mRend.material.color;
        mBuildManager = BuildManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (mBuildManager.GetBuildingToBuild() == null)
        {
            Debug.LogError("Can't build null object");
            return;
        }

        if (mBuilding != null)
        {
            Debug.Log("Something is already here!");
            return;
        }

        GameObject newTurret = mBuildManager.GetBuildingToBuild();
        mBuilding = Instantiate(newTurret, transform.position + mPosOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (mBuildManager.GetBuildingToBuild() == null)
        {
            Debug.LogError("Can't build null object");
            return;
        }
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
