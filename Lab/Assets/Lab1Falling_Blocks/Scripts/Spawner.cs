using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnMinMaxSize;

    [SerializeField]
    private float nextSpawnTime;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnSize = Random.Range(spawnMinMaxSize.x, spawnMinMaxSize.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newblock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.identity);


            newblock.transform.Rotate(0f, 0f, Random.Range(-spawnAngleMax, spawnAngleMax));
            newblock.transform.localScale = new Vector3(spawnSize,spawnSize, 1f);
        }

	}
}
