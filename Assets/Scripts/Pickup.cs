using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public CardType cardType;

	public Camera myCamera;

	[SerializeField] GameObject cardGood;
	[SerializeField] GameObject cardBad;

	int damage;
	bool keep;

	private void Awake() {
		int cardTypeNum = Random.Range(0, 2);
		switch (cardTypeNum) {
			case 0:
				cardType = CardType.Damage;
				cardGood.SetActive(false);
				cardBad.SetActive(true);
				break;
			case 1:
				cardType = CardType.Keep;
				cardGood.SetActive(true);
				cardBad.SetActive(false);
				break;
			//case 2:
				//cardType = CardType.TurnOrder;
				//break;
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

public enum CardType {
	Damage,
	Keep
	//TurnOrder,
}