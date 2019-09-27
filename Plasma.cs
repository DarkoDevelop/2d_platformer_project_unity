using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plasma : MonoBehaviour {

	private Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}


	void OnTriggerEnter2D(Collider2D col){

		if (col.isTrigger != true) {
			if (col.CompareTag ("Player")) {
				col.GetComponent<Player>().takeDMG (1);
				StartCoroutine (player.Knock(0.05f,120f,player.transform.position));
			}
			Destroy (gameObject);
		}

	}
}
