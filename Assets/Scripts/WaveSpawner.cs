using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public Transform mEnemyPrefab;
    public Transform mSpawnPoint;

    public float mSpawnSpacer = .25f;

    public Text mUI;
    public float mTimeBetween = 5f;
    private float mTimeTillNextWave;

    private int mWaveIndex = 0;

	// Use this for initialization
	void Start () {
        mTimeTillNextWave = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        if (mTimeTillNextWave <= 0f)
        {
            StartCoroutine(SpawnWave());
            mTimeTillNextWave = mTimeBetween;
        }

        mTimeTillNextWave -= Time.deltaTime;

        mUI.text = Mathf.Floor(mTimeTillNextWave + 1f).ToString();
    }

    IEnumerator SpawnWave()
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
