using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * WaveSpawner
 * -----------
 * Basic script to control spawning of waves
 * Very simple, only spawns one type of enemy
 * May want to update this in future to give
 * customization to types of waves / # of waves
 * 
 * Possibly also add in ability to read in config
 * files to generate waves instead of purely through code
 */
public class WaveSpawner : MonoBehaviour {

    [Header("Spawn Properties")]
    public Transform mEnemyPrefab;
    public Transform mSpawnPoint;
    public float mTimeBetween = 5f;
    public float mSpawnSpacer = .25f;

    [Header("Text Displays")]
    public Text mWaveTimer;
    public Text mGoldDisplay;
    public Text mLivesRemainingTxt;

    private float mTimeTillNextWave;
    private int mWaveIndex = 0;

	// Use this for initialization
	void Start () {
        mTimeTillNextWave = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        // If its time to spawn, trigger coroutine and update timer
        if (mTimeTillNextWave <= 0f)
        {
            StartCoroutine(SpawnWave());
            mTimeTillNextWave = mTimeBetween;
        }

        // Decrement timer and clamp so that timer never goes negative
        mTimeTillNextWave -= Time.deltaTime;
        mTimeTillNextWave = Mathf.Clamp(mTimeTillNextWave, 0, Mathf.Infinity);

        UpdateStrings();
    }

    private void UpdateStrings()
    {
        // Update Display Strings
        mWaveTimer.text = string.Format("Next Wave: {0:00.00}", mTimeTillNextWave);
        mGoldDisplay.text = string.Format("Gold: {0}", PlayerStats.mGold.ToString());
        mLivesRemainingTxt.text = string.Format("Lives Left: {0}", PlayerStats.mLivesRemaining.ToString());
    }

    private IEnumerator SpawnWave()
    {
        mWaveIndex++;

        //TODO: Spawns 5 enemies for now. More later.
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(mSpawnSpacer);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(mEnemyPrefab, mSpawnPoint.position, mSpawnPoint.rotation);
    }
}
