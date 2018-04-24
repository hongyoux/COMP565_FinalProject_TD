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

    public void SelectAnotherTurret()
    {
        buildManager.SetTurretToBuild(buildManager.mAnotherTurret);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
