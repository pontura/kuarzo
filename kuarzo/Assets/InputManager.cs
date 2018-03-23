using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

	public UIScreen ui;
	public Animation introAnim;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Destroy (GameObject.Find ("Avatars").gameObject);
			Destroy (GameObject.Find ("KinectController").gameObject);

			SceneManager.LoadScene ("TV");
		} 
		if (Input.GetKeyDown (KeyCode.Q)) {
			IntroOn ();
		} else if (Input.GetKeyDown (KeyCode.W)) {
			IntroOff ();
		}
	}
	void IntroOn()
	{
		ui.SetTextField ("intro on");
		introAnim.Play ("intro");
	}
	void IntroOff()
	{
		ui.SetTextField ("intro off");
		introAnim.Play ("introOff");
	}
}
