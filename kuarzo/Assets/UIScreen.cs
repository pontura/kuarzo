using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour {

	public Text field;

	public void SetTextField(string text)
	{
		CancelInvoke ();
		field.text = text;
		Invoke ("Reset", 1);
	}
	void Reset()
	{
		field.text = "";
	}
}
