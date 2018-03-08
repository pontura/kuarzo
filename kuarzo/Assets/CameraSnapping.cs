using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnapping : MonoBehaviour {

	public float lerpingValue;
	public GameObject[] foots;
	public Vector3 offsetPosition;

	void Update () {
		Vector3 pos = transform.position;
		//float offsetX = 0;
		float offsetY = 1000;
		foreach (GameObject foot in foots) {
			//offsetX += foot.transform.position.x;
			if (foot.transform.position.y < offsetY)
				offsetY = foot.transform.position.y;
		}
		//offsetX /= foots.Length;
		offsetY /= foots.Length;
		//pos.x = offsetX;
		pos.y = offsetY;
		pos += offsetPosition;
		transform.position = pos;
	}
}
