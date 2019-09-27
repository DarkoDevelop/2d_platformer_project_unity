using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombie : MonoBehaviour {

	public int currHealth;
	public int maxHealth = 5;
	private Player player;
	public LayerMask enemyMask;
	public float speed = 1;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth, myHeight;

	void Start ()
	{
		currHealth = maxHealth;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
	}

	void FixedUpdate ()
	{
		Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up * myHeight/4;
		Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
		Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2());
		bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f, enemyMask);
		if(!isGrounded || isBlocked)
		{
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}
		//naprijed
		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			player.takeDMG (2);
			StartCoroutine (player.Knockk(0.05f,100f,player.transform.position));
		}
	}
	public void takeDMGEnemy(int dmg){
		currHealth -= dmg;
		if (currHealth <= 0) {
			Destroy (gameObject);
		}
	}
}