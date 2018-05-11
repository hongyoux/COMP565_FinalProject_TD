using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int mGold;
    public int mStartGold;

    public static int mLivesRemaining;
    public int mStartLives;

    private void Start()
    {
        mLivesRemaining = mStartLives;
        mGold = mStartGold;
    }

    public void ReduceLife()
    {

    }
}
