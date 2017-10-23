using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public Vector2 speedMinMax;
    public event System.Action OnPlayerDeath;

    float decendenceSpeed;
    float visableHeightThreshold;

	// Use this for initialization
	void Start () {
        decendenceSpeed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visableHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * decendenceSpeed * Time.deltaTime);

        if(transform.position.y < visableHeightThreshold)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(col.gameObject);
        }
    }
}
