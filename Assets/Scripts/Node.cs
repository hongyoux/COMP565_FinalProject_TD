using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Node
 * ----
 * Base building block class
 * Contains logic for hover over when building
 * as well as stores information about if it already has
 * a building on the tile
 */
public class Node : MonoBehaviour {

    public Color mHoverColor;
    public Color mInvalidColor;
    public Vector3 mPosOffset;
    
    [Header("Optional")]
    public GameObject mBuilding;

    private BuildManager mBuildManager;
    private Renderer mRend;
    private Color mOriginalColor;

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
        // If over UI, ignore click
        // If no building selected, don't do anything
        // Else build a building on currently hovered node
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
        // Hover logic
        // If player has selected a building to place
        // If enough gold -> Highlight tile green
        // If not -> Highlight red
        // Do not highlight if building exists on tile already
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
            if (mBuildManager.HasEnoughMoney)
            {
                mRend.material.color = mHoverColor;
            }
            else
            {
                mRend.material.color = mInvalidColor;
            }
        }
    }

    private void OnMouseExit()
    {
        mRend.material.color = mOriginalColor;
    }
}
