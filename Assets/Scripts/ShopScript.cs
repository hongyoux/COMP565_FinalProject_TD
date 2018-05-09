using UnityEngine;

public class ShopScript : MonoBehaviour {

    public TurretBlueprint mStandardBlueprint;
    public TurretBlueprint mMissileBlueprint;

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

    // Update is called once per frame
    void Update () {
		
	}
}
