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

	public bool ojosActive;
	public bool mouthActive;

	public GameObject mic;
	public GameObject mic_to_instantiate;

	public GameObject cameraMain;
	ParticleSystem micParticles;
	GameObject trailverde;

	void Start () {
		jaw = GameObject.Find ("jaw");
		leftEye  =  GameObject.Find ("leftEye");
		rightEye =  GameObject.Find ("rightEye");

		GameObject oldMic =  GameObject.Find ("mic");

		mic = Instantiate (mic_to_instantiate);
		mic.transform.SetParent (oldMic.transform.parent);
		mic.transform.localScale = oldMic.transform.localScale;
		mic.transform.localPosition = oldMic.transform.localPosition;
		mic.transform.rotation = oldMic.transform.rotation;
		micParticles = mic.GetComponentInChildren<ParticleSystem> ();
		Destroy (oldMic.gameObject);

		if (jaw == null)
			return;
		originalRotation = jaw.transform.localEulerAngles;
		Max_Opened = originalRotation.x + 50;
		Invoke ("Delayed", 0.5f);
	}
	void Delayed()
	{
		trailverde = GameObject.Find ("trailVerde");
	}
	public void SetMouthActive()
	{
		mouthActive = !mouthActive;
		float angle = originalRotation.x + (0 * (Max_Opened - originalRotation.x));
		Vector3 newRot = jaw.transform.localEulerAngles;
		newRot.y = originalRotation.y;
		newRot.z = originalRotation.z;
		newRot.x = angle;
		jaw.transform.localEulerAngles = newRot;
	}
	public void SetOjosActive()
	{
		if (leftEye == null || rightEye == null)
			return;
		ojosActive = !ojosActive;
		leftEye.SetActive (false);
		rightEye.SetActive (false);
	}
	void Update () {
		
		float jawValue = manager.GetAnimUnit(KinectInterop.FaceShapeAnimations.JawOpen);
		float eyesValue = manager.GetAnimUnit(KinectInterop.FaceShapeAnimations.LefteyeClosed);
		//print (jawValue);
		if (jaw != null && mouthActive)
			UpdateJaw (jawValue);
		if (leftEye != null && ojosActive)
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
	public void SetMicTrail(bool isOn)
	{
		mic.GetComponent<TrailRenderer> ().enabled = isOn;
	}
	public void SetMicParticles(bool isOn)
	{
		micParticles.gameObject.SetActive (isOn);
	}
	public void SetTrailVerde(bool isOn)
	{
		trailverde.SetActive (isOn);
	}
	public void MoveCamera(float _y)
	{
		Vector3 pos = cameraMain.transform.localPosition;
		pos.y += _y;
		cameraMain.transform.localPosition = pos;
	}
		
}
