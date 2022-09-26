using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public GameObject myGameObject;

	public Camera myCamera;

	int damage;
	bool keep;

	private void Start() {
		//myGameObject = GetComponent<GameObject>();
		//myCamera = myGameObject.GetComponent<Camera>();

		transform.LookAt( myCamera.transform.position );
	}
}
