using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public GameObject mStandardTurret;
    public GameObject mMissileLauncher;
    public GameObject mLaserBeamTower;

    public GameObject mBuildEffect;

    public bool CanBuild
    {
        get
        {
            return mSelectedBuilding != null;
        }
    }

    public bool HasEnoughMoney
    {
        get
        {
            return PlayerStats.mGold >= mSelectedBuilding.mCost;
        }
    }

    private TurretBlueprint mSelectedBuilding;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager is in the scene! BAD");
            return;
        }
        instance = this;
    }
    
    public void SelectTurretToBuild(TurretBlueprint blueprint)
    {
        mSelectedBuilding = blueprint;
    }

    public void BuildTurretOn(Node n)
    {
        if (PlayerStats.mGold < mSelectedBuilding.mCost)
        {
            return;
        }
        GameObject building = Instantiate(mSelectedBuilding.mPrefab, n.GetBuildPosition(), Quaternion.identity);
        GameObject buildFX = Instantiate(mBuildEffect, n.GetBuildPosition(), Quaternion.identity);
        Destroy(buildFX, 5f);

        n.mBuilding = building;
        PlayerStats.mGold -= mSelectedBuilding.mCost;
    }
}
