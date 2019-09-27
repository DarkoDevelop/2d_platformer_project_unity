using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float smoothTimeX;
	Transform cameraTransf;
	public float CameraSpeed = 3f;
	float speed = 1.2f;
	public float move = 0f;
	public float movealiitle = 0f;

	private Vector2 velocity;

	void Start () {
		cameraTransf = this.transform;
	}
	void FixedUpdate () {
		transform.position = new Vector3 (transform.position.x, CameraSpeed * speed * Time.deltaTime + movealiitle, transform.position.z);
		CameraSpeed++;
		speed = speed + 0.001f;
	}
	void Update(){
		//if (moveWithPlayer ()) {
		//	movealiitle = 4f;
		//} else {
		//	movealiitle = 0f;
		//}
	}

	}

