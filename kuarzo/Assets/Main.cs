using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	
	public FacetrackingManager manager;
	public GameObject jaw;
	public float defaultX = 89;
	public float jawSmooth;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float jawValue = manager.GetAnimUnit(KinectInterop.FaceShapeAnimations.JawOpen);
		//print (jawValue);
		UpdateJaw (jawValue);
	}
	void UpdateJaw(float value)
	{
		if (value < 0.3f)
			value = 0;
		
		Vector3 newRot = jaw.transform.localEulerAngles;
		newRot.y = 0;
		newRot.z = 0;
		float _x = Mathf.Lerp(newRot.x, value * (jawSmooth) + defaultX, 0.15f);
		newRot.x = _x;
		jaw.transform.localEulerAngles = newRot;
	}
}
