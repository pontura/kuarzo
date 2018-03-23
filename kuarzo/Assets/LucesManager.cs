﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesManager : MonoBehaviour {

	public GameObject standard;
	public GameObject flash0;
	public GameObject flash1;
	public GameObject flash2;

	public GameObject mood1;
	public GameObject mood2;

	void Start()
	{
		Reset ();
	}
	public void Reset() {
		OffAll ();
		standard.SetActive (true);
	}
	public void Mood(int id)
	{
		OffAll ();
		switch(id)
		{
		case 1:
			mood1.SetActive (true);
			break;
		case 2:
			mood2.SetActive (true);
			break;
		}
	}
	public void Flash(int id)
	{
		switch (id) {
		case 0:
			flash0.SetActive (true);
			break;
		case 1:
			flash1.SetActive (true);
			break;
		case 2:
			flash2.SetActive (true);
			break;
		}
	}
	void OffAll()
	{
		standard.SetActive (false);
		mood1.SetActive (false);
		mood2.SetActive (false);
	}


	public bool isFlashing;
	float flashingSpeed;
	float rand_flash_0;
	float rand_flash_1;
	float rand_flash_2;

	public void LoopFlash()
	{
		isFlashing = !isFlashing;
		timer = 0;
		flashingSpeed = 0.5f;
		rand_flash_0 = GetRand ();
		rand_flash_1 = GetRand ();
		rand_flash_2 = GetRand ();
	}
	float GetRand()
	{
		return flashingSpeed + (float)(Random.Range (0, 10)) / 80f;
	}
	float timer;
	void Update()
	{
		if (!isFlashing)
			return;

		timer += Time.deltaTime;

		if (timer > rand_flash_0) {
			Flash (0);
			rand_flash_0 += GetRand ();
		}
		if (timer > rand_flash_1) {
			Flash (1);
			rand_flash_1 += GetRand ();
		}
		if (timer > rand_flash_2) {
			Flash (2);
			rand_flash_2 += GetRand ();
		}

	}

}