using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

	public float intensity;

	float i;
	float speed = 60;
	Light light;

	void Start()
	{
		light = GetComponentInChildren<Light> ();
	}
	void OnEnable () {		
		i = intensity;
	}

	void Update () {
		i -= Time.deltaTime * speed;
		light.intensity = i;
		if (i <= 0)
			gameObject.SetActive (false);
	}
}
