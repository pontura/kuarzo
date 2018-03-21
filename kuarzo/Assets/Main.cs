using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	
	public FacetrackingManager manager;
	GameObject jaw;
	float Max_Opened;
	public float newAnlge;
	Vector3 originalRotation;

	void Start () {
		jaw = GameObject.Find ("jaw");
		if (jaw == null)
			return;
		originalRotation = jaw.transform.localEulerAngles;
		Max_Opened = originalRotation.x + 50;

	}
	
	// Update is called once per frame
	void Update () {
		if (jaw == null)
			return;
		float jawValue = manager.GetAnimUnit(KinectInterop.FaceShapeAnimations.JawOpen);
		//print (jawValue);
		UpdateJaw (jawValue);
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
}
