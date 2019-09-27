using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliders : MonoBehaviour {

	private Player player;
	public int TakeDMG = 100;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			player.takeDMG (TakeDMG);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
