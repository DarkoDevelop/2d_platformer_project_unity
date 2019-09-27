using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliders1 : MonoBehaviour {

	private Player player;
	public float SmoothTime = 0.5f;
	private Vector3 Velocity = Vector3.zero;
	public Camera camera;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}


	
	// Update is called once per frame
	void Update () {
		
	}
	void MoveCameraALittle(){

		camera.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			MoveCameraALittle ();
		}
	}
}
