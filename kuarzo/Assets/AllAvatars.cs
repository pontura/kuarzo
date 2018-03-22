using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAvatars : MonoBehaviour {

	public List<GameObject> chicos;
	public List<GameObject> chicas;

	void Start () {
		DontDestroyOnLoad (this);
	}

}
