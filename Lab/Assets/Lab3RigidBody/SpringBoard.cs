using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour {

    public Vector3 force;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
            Debug.Log("SpringBoard");
        }
    }
}
