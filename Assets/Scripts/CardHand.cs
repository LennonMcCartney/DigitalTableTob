using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour {

	public Pickup[] cards;

	public Player player;

	private void Start() {
		cards = FindObjectsOfType<Pickup>();

		LayoutCards();
	}

	private void Update() {
		//foreach (Pickup pickup in cards) {
		//cards.Add(Instantiate(pickup, transform.position, Quaternion.identity));
		//}
	}

	void LayoutCards() {
		int currentCard = 0;
		float offset = 1f;
		foreach (Pickup card in cards) {
			currentCard++;

			Debug.Log(card);

			float rotation = 180 * (currentCard / card.transform.localScale.x) + player.transform.eulerAngles.y;

			Vector3 offsetVector = new Vector3(Mathf.Sin(rotation) * offset, 0, Mathf.Cos(rotation) * offset);
			
			card.transform.position = player.transform.position + offsetVector;

			card.Look();
		}
	}
}