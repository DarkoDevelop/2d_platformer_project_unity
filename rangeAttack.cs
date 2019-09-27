using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour {

	public Spider spider;

	void Awake(){
		spider = gameObject.GetComponentInParent<Spider> ();
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			spider.Attack ();
		}
	}
}
