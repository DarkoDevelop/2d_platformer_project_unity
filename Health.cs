using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Sprite[] heartSprites;
	public Image HeartsUI;
	private Player player;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		HeartsUI.sprite = heartSprites[player.currentHealth];
	}
}
