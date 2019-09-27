using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BloodHit : MonoBehaviour {

	public Text Hitss;

	static public float time = 0f;
	private float time2 = 0f;
	public bool timeron = false;
	private int dva = 2;
	private string novo;
	private Player player;
	void Start () {
		if (Application.loadedLevel == 2) {
			timeron = false;
			Hitss.text = time.ToString ("0.0");
		} else { timeron = true;
		}	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timeron) {
			time += Time.deltaTime;
			//time2 = (float)Mathf.Round (time ,2);
			Hitss.text = time.ToString ("0.0");
		}
		//Hitss.text = player.position.y.ToString ();
	}
}

