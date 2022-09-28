using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	int lives = 4;

	public int turnsToSkip = 0;

	public List<Pickup> cards;

	//public Player player;

	private void Start() {
		cards = new List<Pickup>(FindObjectsOfType<Pickup>());

		LayoutCards();
	}

	private void Update() {
		//foreach (Pickup pickup in cards) {
		//cards.Add(Instantiate(pickup, transform.position, Quaternion.identity));
		//}
	}

	public void LayoutCards() {
		int currentCard = 0;
		float offset = 1.5f;
		foreach (Pickup card in cards) {
			currentCard++;

			float rotation = 180 * ((float)currentCard / (float)cards.Count) + transform.eulerAngles.y;

			Vector3 offsetVector = new Vector3(Mathf.Sin(Mathf.Deg2Rad * rotation) * offset, 0, Mathf.Cos(Mathf.Deg2Rad * rotation) * offset);

			card.transform.position = transform.position + offsetVector;

			card.Look();
		}
	}
}
