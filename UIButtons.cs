using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false; 

	void Start () {
		PauseUI.SetActive(false);
	}

	void Update () {
		if (Input.GetKeyDown("p")) {
			paused = !paused;
			if (paused) {
				PauseUI.SetActive (true);
				Time.timeScale = 0;
			} else {
				PauseUI.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}
	public void Resume(){
		PauseUI.SetActive(false);
		Time.timeScale = 1;
	}
	public void restart(){
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;
	}
	public void mainmenu(){
		Application.LoadLevel (0);
	}
	public void quit(){
		Application.Quit ();
	}
}
