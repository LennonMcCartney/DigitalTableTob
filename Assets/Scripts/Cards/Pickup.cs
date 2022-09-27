using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public GameObject myGameObject;

	public Camera myCamera;

	int damage;
	bool keep;

	public void Look() {
		transform.LookAt(myCamera.transform.position);
	}
}
