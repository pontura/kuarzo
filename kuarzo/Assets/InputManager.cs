using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

	public UIScreen ui;
	public Animation introAnim;
	public LucesManager lucesManager;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Destroy (GameObject.Find ("Avatars").gameObject);
			Destroy (GameObject.Find ("KinectController").gameObject);

			SceneManager.LoadScene ("TV");
		} 
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Ojos();
		} 
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Mouth();
		} 
		if (Input.GetKeyDown (KeyCode.Q)) {
			IntroOn ();
		} else if (Input.GetKeyDown (KeyCode.W)) {
			IntroOff ();
		} else if (Input.GetKeyDown (KeyCode.Z)) {
			Flash0 ();
		} else if (Input.GetKeyDown (KeyCode.X)) {
			Flash1 ();
		} else if (Input.GetKeyDown (KeyCode.C)) {
			Flash2 ();
		} else if (Input.GetKeyDown (KeyCode.A)) {
			LoopFlash ();
		} 
		if (Input.GetKeyDown (KeyCode.P)) 
			ResetLights ();
		if (Input.GetKeyDown (KeyCode.O)) 
			Mood (1);
		if (Input.GetKeyDown (KeyCode.I)) 
			Mood (2);
		
	}
	void Ojos()
	{
		GetComponent<Main> ().SetOjosActive ();
		ui.SetTextField ("Ojos " + GetComponent<Main> ().ojosActive);
	}
	void Mouth()
	{
		GetComponent<Main> ().SetMouthActive ();
		ui.SetTextField ("Boca " + GetComponent<Main> ().ojosActive);
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
	void Flash0()
	{
		lucesManager.Flash (0);
	}
	void Flash1()
	{
		lucesManager.Flash (1);
	}
	void Flash2()
	{
		lucesManager.Flash (2);
	}
	void LoopFlash()
	{		
		lucesManager.LoopFlash ();
		ui.SetTextField ("Flash " + lucesManager.isFlashing);
	}
	void ResetLights()
	{
		lucesManager.Reset ();
	}
	void Mood(int id)
	{
		lucesManager.Mood (id);
	}
}
