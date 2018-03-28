using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAvatar : MonoBehaviour {

	GameObject avatar;

	// Use this for initialization
	void Awake () {
		//avatar = transform.parent.gameObject.GetComponentInChildren<Animator> ().gameObject;

		foreach (GameObject go in Object.FindObjectsOfType(typeof(GameObject))) {
			Animator a = go.GetComponent<Animator> ();
			if (a != null)
				avatar = a.gameObject;
		}
		if(avatar!=null)
			SetAvatarController (avatar);
	}

	void SetAvatarController(GameObject go){
		go.AddComponent<AvatarController>();
		AvatarController ac = avatar.GetComponent<AvatarController> ();
		ac.mirroredMovement = true;
		ac.verticalMovement = true;
		ac.groundedFeet = true;
		ac.applyMuscleLimits = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
