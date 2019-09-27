using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	private Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coli){
		if (coli.isTrigger != true) {
			Debug.Log ("Trigger na bilo sta");
			if (coli.CompareTag ("Player")) {
				coli.GetComponent<Player>().GiveHEALTH(1);
				Destroy (gameObject);
			}
		}

	}
}
