using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public GameObject myGameObject;

	public Camera myCamera;

	int damage;
	bool keep;

	private void Start() {
		
	}

	public void Look() {
		transform.LookAt(myCamera.transform.position);
	}

	private void OnMouseDown() {
		Debug.Log("Clicked");
	}
}

enum CardType {
	Damage,
	Keep,
	TurnOrder,
}