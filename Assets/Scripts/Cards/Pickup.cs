using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	CardType cardType;

	public Camera myCamera;

	int damage;
	bool keep;

	private void Awake() {
		int cardTypeNum = Random.Range(0, 3);
		switch (cardTypeNum) {
			case 0:
				cardType = CardType.Damage;
				break;
			case 1:
				cardType = CardType.Keep;
				break;
			case 2:
				cardType = CardType.TurnOrder;
				break;
			default:
				Debug.Log("Card type num invalid");
				break;
		}
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