using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int mGold;
    public int mStartGold;

    private void Start()
    {
        mGold = mStartGold;
    }
}
