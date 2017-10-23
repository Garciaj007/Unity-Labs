using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 7;

    float ScreenHalfWidthInWorldUnits;

	// Use this for initialization
	void Start () {
        ScreenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        ScreenHalfWidthInWorldUnits = ScreenHalfWidthInWorldUnits - transform.localScale.x/2;
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x <  -ScreenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(ScreenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > ScreenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-ScreenHalfWidthInWorldUnits, transform.position.y);
        }
	}
}
