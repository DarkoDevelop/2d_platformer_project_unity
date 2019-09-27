using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
	//private Spider spider; 
	public Player player;
	public MovingPlatforms moving;

	void Start(){
	//	spider = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<Spider> ();
		player = gameObject.GetComponentInParent<Player> ();
	}
	void OnTriggerEnter2D(Collider2D col){
		if (!(col.gameObject.name == "AttackRange")) {
			player.ground = true;
	//	Debug.Log ("" + col.gameObject.name);
		}

	}

	void OnTriggerStay2D(Collider2D col){
		if (!(col.gameObject.name == "AttackRange")) {
			player.ground = true;
	//		Debug.Log ("" + col.gameObject.name);
		}
		if (col.gameObject.name == "sheet_21") {

		}
	}

	void OnTriggerExit2D(Collider2D col){
		player.ground = false;
	}

}
