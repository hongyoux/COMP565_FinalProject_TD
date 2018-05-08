using UnityEngine;

public class ShopScript : MonoBehaviour {

    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.mStandardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.mMissileLauncher);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
