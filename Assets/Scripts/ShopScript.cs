using UnityEngine;

/**
 * ShopScript
 * ----------
 * Helper class utilized by UI to pick which towers
 * to spawn if node is clicked.
 */
public class ShopScript : MonoBehaviour {

    [Header("Building Blueprints")]
    public TurretBlueprint mStandardBlueprint;
    public TurretBlueprint mMissileBlueprint;
    public TurretBlueprint mLaserBlueprint;

    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    /**
     * Button click on Standard turret
     */
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(mStandardBlueprint);
    }

    /**
     * Button click on Missile turret
     */
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(mMissileBlueprint);
    }

    /**
     * Button click on Laser turret
     */
    public void SelectLaserBeamTower()
    {
        buildManager.SelectTurretToBuild(mLaserBlueprint);
    }

}
