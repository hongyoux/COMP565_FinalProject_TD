using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * PlayerStats
 * -----------
 * These are tracked variables for things that
 * change during the course of a level or game
 * such as gold or lives.
 * Maybe in future there can be other things here
 * like special resources, score, etc.
 */
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
}
