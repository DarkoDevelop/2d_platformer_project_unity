using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoWithTheFlaw : MonoBehaviour {

public GameObject target;
private Vector3 offset;
void Start(){
	target = null;
	}
	void OnTriggerStay2D(Collider2D col){
		target = col.gameObject;
		offset = target.transform.position - transform.position;
	}
	void OnTriggerExit2D(Collider2D col){
		target = null;
	}
	void FixedUpdate(){
			target.transform.position = this.transform.position+offset;
	}
}