﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

	public UIScreen ui;
	public IntroOutro introOutro;
	public LucesManager lucesManager;
	Main main;

	void Start()
	{
		main = GetComponent<Main> ();
		main.SetMicTrail (false);
		main.SetMicParticles (false);
	}

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
		if (Input.GetKeyDown (KeyCode.P)) {
			ResetLights ();
			main.SetMicTrail (false);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			main.SetMicTrail (true);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
			Mood (1);
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			main.SetMicTrail (false);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
			Mood (2);
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			main.SetMicTrail (false);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
			Mood (3);
		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			main.SetMicTrail (false);
			main.SetMicParticles (true);
			main.SetTrailVerde (false);
			Mood (4);
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			main.SetMicTrail (true);
			main.SetMicParticles (false);
			main.SetTrailVerde (true);
			Mood (5);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			main.SetMicTrail (false);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
			Mood (6);
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			main.SetMicTrail (false);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
			Mood (7);
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			main.SetMicTrail (false);
			main.SetMicParticles (false);
			main.SetTrailVerde (false);
			Mood (8);
		}

		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			main.MoveCamera (0.01f);
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			main.MoveCamera (-0.01f);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			ui.SetTextField ("Rotate Kinect +1");
			main.RotateCamera (1);
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ui.SetTextField ("Rotate Kinect -1");
			main.RotateCamera (-1);
		}
		
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
		introOutro.Init (true);
	}
	void IntroOff()
	{
		introOutro.Init (false);
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
