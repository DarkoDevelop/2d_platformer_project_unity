using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {

	Transform transformP;
	void Start () {
		transformP = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transformP.position = new Vector3 (Mathf.PingPong (Time.time, 3), transform.position.y, transform.position.z);
	}
}
