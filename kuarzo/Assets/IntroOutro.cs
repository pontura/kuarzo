using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroOutro : MonoBehaviour {

	public Camera mainCamera;
	public GameObject panel;
	Animation anim;

	void Start()
	{
		anim = GetComponent<Animation> ();
		panel.SetActive (false);
	}

	public void Init(bool isIntro) {		
		panel.SetActive (true);
		anim.Play ("intro");
	}
}
