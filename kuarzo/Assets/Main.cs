using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	
	public FacetrackingManager manager;
	GameObject jaw;
	float Max_Opened;
	public float newAnlge;
	Vector3 originalRotation;
	GameObject leftEye;
	GameObject rightEye;

	void Start () {
		jaw = GameObject.Find ("jaw");
		leftEye  =  GameObject.Find ("leftEye");
		rightEye =  GameObject.Find ("rightEye");
		if (jaw == null)
			return;
		originalRotation = jaw.transform.localEulerAngles;
		Max_Opened = originalRotation.x + 50;

	}
	
	// Update is called once per frame
	void Update () {
		
		float jawValue = manager.GetAnimUnit(KinectInterop.FaceShapeAnimations.JawOpen);
		float eyesValue = manager.GetAnimUnit(KinectInterop.FaceShapeAnimations.LefteyeClosed);
		//print (jawValue);
		if (jaw != null)
			UpdateJaw (jawValue);
		if (leftEye != null)
			UpdateEyes (eyesValue);
	}

	void UpdateJaw(float value)
	{
		if (value < 0.12f)
			value = 0;

		newAnlge = originalRotation.x + (value * (Max_Opened - originalRotation.x));

		Vector3 newRot = jaw.transform.localEulerAngles;
		newRot.y = originalRotation.y;
		newRot.z = originalRotation.z;
		newRot.x = Mathf.Lerp(newRot.x, newAnlge, 0.8f);
		jaw.transform.localEulerAngles = newRot;
	}
	void UpdateEyes(float value)
	{
		if (value < 0.4f) {
			leftEye.SetActive (false);
			rightEye.SetActive (false);
		} else {
			leftEye.SetActive (true);
			rightEye.SetActive (true);
		}
	}
}
