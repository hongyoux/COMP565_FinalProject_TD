using UnityEngine;

public class ShopScript : MonoBehaviour {

    public TurretBlueprint mStandardBlueprint;
    public TurretBlueprint mMissileBlueprint;
    public TurretBlueprint mLaserBlueprint;

    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(mStandardBlueprint);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(mMissileBlueprint);
    }
    public void SelectLaserBeamTower()
    {
        buildManager.SelectTurretToBuild(mLaserBlueprint);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
