using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlasmaPlayer : MonoBehaviour {

	private Spider spider;
	private EnemyZombie zombie;
	void Start () {

		zombie = GameObject.FindGameObjectWithTag ("Zombie").GetComponent<EnemyZombie> ();
		spider = GameObject.FindGameObjectWithTag ("Enemy").GetComponent<Spider> ();
	}
	
	void OnTriggerEnter2D(Collider2D coli){
		if (coli.isTrigger != true) {
			Debug.Log ("Trigger na bilo sta");
			if (coli.CompareTag ("Enemy")) {
				coli.GetComponent<Spider>().takeDMGEnemy (1);
				Destroy (gameObject);
			}
			if (coli.CompareTag ("Zombie")) {
				coli.GetComponent<EnemyZombie>().takeDMGEnemy (1);
				Debug.Log("Coll sa zombijem");
				Destroy (gameObject);
			}
		}

	}
}
