using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backrounds;
	private float[] parallaxScales;
	public float smoothing = 1f;

	private Transform cam;
	private Vector3 previousCamPos;

	void Awake(){
		cam = Camera.main.transform;
	}
		
	void Start () {
		previousCamPos = cam.position;
		parallaxScales = new float[backrounds.Length];
		for(int i = 0;i < backrounds.Length; i++){
			parallaxScales [i] = backrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales [i];
			float backroundTargetPosX = backrounds [i].position.x + parallax;
			Vector3 backroundTargetPos = new Vector3 (backroundTargetPosX, backrounds [i].position.y, backrounds [i].position.z);
			backrounds [i].position = Vector3.Lerp(backrounds[i].position, backroundTargetPos, smoothing * Time.deltaTime);

		}
		previousCamPos = cam.position;
	}
}
