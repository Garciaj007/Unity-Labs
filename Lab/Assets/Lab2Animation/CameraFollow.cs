using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;

    private Camera mainCamera;
    private Transform player;

	// Use this for initialization
	void Start () {
        mainCamera = this.GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        mainCamera.transform.position = player.position + offset;
	}
}
