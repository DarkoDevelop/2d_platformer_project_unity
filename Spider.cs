using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

	public int currHealth;
	public int maxHealth = 5;
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed = 10;
	public float bulletTimmer;
	public bool awake = false;
	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform ShootFrom;

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
	}

	void Start () {
		currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Awake", awake);
		RangeCheck ();
	}

	void RangeCheck(){
		distance = Vector3.Distance (transform.position, target.transform.position);
		if (distance < wakeRange) {
			awake = true;
		}
		if (distance > wakeRange) {
			awake = false;
		}
	}
	public void Attack(){
		bulletTimmer += Time.deltaTime;

		if (bulletTimmer >= shootInterval) {

			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			GameObject bulletFlow;
			bulletFlow = Instantiate (bullet, ShootFrom.transform.position, ShootFrom.transform.rotation) as GameObject;
			bulletFlow.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			bulletTimmer = 0;

		}
	}
	public void takeDMGEnemy(int dmg){
		currHealth -= dmg;
		if (currHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
