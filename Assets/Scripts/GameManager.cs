using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool mGameEnded = false;

	// Update is called once per frame
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
