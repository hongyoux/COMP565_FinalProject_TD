using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color mHoverColor;
    public Vector3 mPosOffset;
    
    [Header("Optional")]
    public GameObject mBuilding;

    private BuildManager mBuildManager;
    private Renderer mRend;
    private Color mOriginalColor;

    // Use this for initialization
    void Start () {
        mRend = GetComponent<Renderer>();
        mOriginalColor = mRend.material.color;
        mBuildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + mPosOffset;
    }	

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!mBuildManager.CanBuild)
        {
            Debug.LogError("Can't build null object");
            return;
        }

        if (mBuilding != null)
        {
            Debug.Log("Something is already here!");
            return;
        }

        mBuildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!mBuildManager.CanBuild)
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
