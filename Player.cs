using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public AudioSource audioHealth;
	public AudioSource audioAMMO;
	public AudioSource jumpSound;
	public AudioSource hitSound;
	public AudioSource RealJump;
	public int shootNumber = 30;
	public Vector2 position;
	public float fireRatePlayer = 0;
	public float damagePlayer = 2;
	float timeToFire;
	Transform firePoint;
	public GameObject bullet;
	public float bulletSpeedPlayer;

	public float maxSpeed = 700f;
	public float speed = 400f;
	public float jumpPower = 100f;

	public bool ground;

	private Rigidbody2D rb2d;
	private Animator anim;

	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	public int currentHealth = 9;
	public int maxHealth = 10;
	void Awake(){
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No Firepoint, provjeri");
		}
	}

	void Start () {
		
		currentHealth = maxHealth;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", ground);
		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));

		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetButtonDown ("Jump") && ground) {
			rb2d.AddForce (Vector2.up * jumpPower);
			RealJump.Play ();
			jumpPower = jumpPower + 10f;
		}
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth <= 0) {
			DIE ();
		}
		/*
		if (fireRatePlayer == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRatePlayer;
				Shoot ();
			}
		}*/
	}
		
	void FixedUpdate(){
		Vector3 easeVel = rb2d.velocity;
		easeVel.y = rb2d.velocity.y;
		easeVel.z = 0.0f;
		easeVel.x *= 1f;
		float h = Input.GetAxis("Horizontal");
		if (ground) {
			rb2d.velocity = easeVel;
		}


		rb2d.AddForce ((Vector2.right * speed) * h);
		if(rb2d.velocity.x > maxSpeed){
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if(rb2d.velocity.x < maxSpeed){
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}

	void DIE(){

		Application.LoadLevel (2);
	}
	public void takeDMG(int dmg){
		jumpSound.Play ();
		currentHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("TIM_HURT");
	}
	public void GiveHEALTH(int hlt){
		audioHealth.Play ();
		currentHealth += hlt;
		}
	public void GiveAMMO(int hlt){
		shootNumber += hlt;
		audioAMMO.Play ();
	}

	public IEnumerator Knock(float knockDur, float knockBackPower, Vector3 knockBack){
		float timer = 0;
		while (knockDur > timer) {
			timer += Time.deltaTime;
			rb2d.AddForce (new Vector3 (transform.position.x, knockBack.y * knockBackPower, transform.position.z));
		}
		yield return 0;
	}
	public IEnumerator Knockk(float knockDur, float knockBackPower, Vector3 knockBack){
		float timer = 0;
		while (knockDur > timer) {
			timer += Time.deltaTime;
			rb2d.AddForce (new Vector3 (transform.position.x -110, knockBack.y - knockBackPower/2, transform.position.z));
		}
		yield return 0;
	}

	Vector2 GetPosMouse(){
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToViewportPoint (Input.mousePosition).x - 0.5f, Camera.main.ScreenToViewportPoint (Input.mousePosition).y - 0.45f);
		return mousePosition;
	}
		/*
	void Shoot(){
		if (shootNumber > 0) {
			Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
			GameObject bulletFlow;
			bulletFlow = Instantiate (bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
			bulletFlow.GetComponent<Rigidbody2D> ().velocity = GetPosMouse () * bulletSpeedPlayer;
			PlayANIMSHOOT ();
			hitSound.Play ();
		
		} else {
			Debug.Log ("hehe, osto bez metaka");
		}
		shootNumber--;
		if (shootNumber <= 0) {
			shootNumber = 0;
		}
	}*/

	int ShootNumber(){
		return shootNumber;
	}
	void PlayANIMSHOOT(){
		gameObject.GetComponent<Animation> ().Play ("TIM_SHOOT");
	}
}
		

