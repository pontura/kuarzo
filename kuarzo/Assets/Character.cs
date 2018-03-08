using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class Character : MonoBehaviour {

	public GameObject SpineBase;
	public GameObject AnkleLeft;
	public GameObject ElbowLeft;
	public GameObject FootLeft;
	public GameObject HandLeft;
	public GameObject HandTipLeft;
	public GameObject HipLeft;
	public GameObject KneeLeft;
	public GameObject ThumbLeft;
	public GameObject WristLeft;
	public GameObject ShoulderLeft;

	public float multiplier;

	void Start () {
		
	}
	public void ReceiveData(Body[] _Data)
	{
		if (_Data.Length > 0) {
			foreach (Body b in _Data) {
				if (b.IsTracked) {
					print (b.Joints.Count);
					foreach(KeyValuePair<JointType, Windows.Kinect.Joint> v in  b.Joints)
					{
						Vector3 pos = new Vector3 (v.Value.Position.X, v.Value.Position.Y, v.Value.Position.Z);
						Quaternion rot = new Quaternion (b.JointOrientations [v.Key].Orientation.X, b.JointOrientations [v.Key].Orientation.Y, b.JointOrientations [v.Key].Orientation.Z, b.JointOrientations [v.Key].Orientation.W);
						UpdatePart (b.Joints [v.Key].JointType, pos, rot);
					}
				}
				//return;
			}
		}
	}
	public void UpdatePart(JointType type, Vector3 pos, Quaternion rot)
	{
		GameObject part = null;
		print (type);

		switch (type) {
		case JointType.SpineBase:
			part = SpineBase;
			break;
		case JointType.AnkleLeft:
			part = AnkleLeft;
			break;
		case JointType.ElbowLeft:
			part = ElbowLeft;
			break;
		case JointType.FootLeft:
			part = FootLeft;
			break;
		case JointType.HandLeft:
			part = HandLeft;
			break;		
		case JointType.HandTipLeft:
			part = HandTipLeft;
			break;
		case JointType.HipLeft:
			part = HipLeft;
			break;
		case JointType.KneeLeft:
			part = KneeLeft;
			break;
		case JointType.ShoulderLeft:
			part = ShoulderLeft;
			break;
		case JointType.ThumbLeft:
			part = ThumbLeft;
			break;
		case JointType.WristLeft:
			part = WristLeft;
			break;
		}
		if (part == null)
			return;

		//Vector3 pos2 = new Vector3(pos.x * 1.6584f, pos.z * -1.7944f + 5.0f, 0.0f);
		// Debug.Log("Usr: (" + csp.X.ToString() + "," + csp.Y.ToString() + "," + csp.Z.ToString() + ") - Pos: " + pos.ToString());
		
		//part.transform.position = pos * multiplier;
		//Vector3 rota = rot.eulerAngles;
		//rota.z -= 90;
		//part.transform.localEulerAngles = rota;
		part.transform.rotation = rot;
	}
}
