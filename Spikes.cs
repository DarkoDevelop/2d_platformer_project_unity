using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour {

	private Player player;
	public int TakeDMG;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			player.takeDMG (TakeDMG);
			StartCoroutine (player.Knock(0.09f,120f,player.transform.position));
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}

}
