using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesManager : MonoBehaviour {

	public GameObject standard;
	public GameObject flash0;
	public GameObject flash1;
	public GameObject flash2;

	public GameObject mood1;
	public GameObject mood2;
	public GameObject mood3;
	public GameObject mood4;
	public GameObject mood5;
	public GameObject mood6;

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
		case 3:
			mood3.SetActive (true);
			break;
		case 4:
			mood4.SetActive (true);
			break;
		case 5:
			mood5.SetActive (true);
			break;
		case 6:
			mood6.SetActive (true);
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
		mood3.SetActive (false);
		mood4.SetActive (false);
		mood5.SetActive (false);
		mood6.SetActive (false);
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
