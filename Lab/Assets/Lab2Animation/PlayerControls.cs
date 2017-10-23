using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            vertical = vertical / 2;
        }

        anim.SetFloat("Forward", vertical, 0.2f, Time.deltaTime);
        anim.SetFloat("Turn", horizontal, 0.2f, Time.deltaTime);
	}
}
