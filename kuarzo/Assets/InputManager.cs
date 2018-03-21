using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

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
		introAnim.Play ("intro");
	}
	void IntroOff()
	{
		introAnim.Play ("introOff");
	}
}
