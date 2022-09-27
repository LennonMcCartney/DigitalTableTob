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
		float offset = 1.5f;
		foreach (Pickup card in cards) {
			currentCard++;

			float rotation = 180 * ((float)currentCard / (float)cards.Length) + transform.eulerAngles.y;

			Vector3 offsetVector = new Vector3(Mathf.Sin(Mathf.Deg2Rad * rotation) * offset, 0, Mathf.Cos(Mathf.Deg2Rad * rotation) * offset);
			
			card.transform.position = player.transform.position + offsetVector;

			card.Look();
		}
	}
}