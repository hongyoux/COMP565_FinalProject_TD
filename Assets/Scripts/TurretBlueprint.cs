using System.Collections;
using UnityEngine;

/**
 * TurretBlueprint
 * ---------------
 * Class that stores values used to create buildings
 * In future, can include additional properties like
 * Recipes for how to make combination towers, etc.
 * Or limited resource blueprints (ie. Only 3 laser towers allowed)
 */
[System.Serializable]
public class TurretBlueprint {

    public GameObject mPrefab;
    public int mCost;
}
