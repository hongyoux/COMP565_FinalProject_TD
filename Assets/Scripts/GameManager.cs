using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * GameManager
 * -----------
 * Currently only prints debug when game is over
 * Eventually maybe endgame screen or restart game.
 */
public class GameManager : MonoBehaviour {
    private bool mGameEnded = false;

	void Update () {
        if (mGameEnded)
        {
            return;
        }

		if (PlayerStats.mLivesRemaining <= 0)
        {
            EndGame();
        }
	}

    private void EndGame()
    {
        mGameEnded = true;
        Debug.Log("GAMEOVER");
    }
}
