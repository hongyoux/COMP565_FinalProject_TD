using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private GameObject mSelectedBuilding;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager is in the scene! BAD");
            return;
        }
        instance = this;
    }

    public GameObject mStandardTurret;

    private void Start()
    {
        mSelectedBuilding = mStandardTurret;
    }

    public GameObject GetBuildingToBuild()
    {
        return mSelectedBuilding;
    }
}
