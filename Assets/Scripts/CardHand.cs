using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour {
	public List<GameObject> cards;

	private void Start() {
	}

	private void Update() {
		foreach ( GameObject pickup in cards ) {
			cards.Add( Instantiate( pickup, transform.position, Quaternion.identity ) );
		}
	}

    /*
    void LayoutCards() {
        int currentCard = 0;
        float offset = 1f;
        foreach (Card card in Cards) {
            currentCard++;

            int rotation = 180 * (currentCard / Cards.Length) + player.transform.eulerAngles.Y;

            Vector3 offsetVector = new Vector3(Mathf.Sin(rotation) * offset, 0, Mathf.Cos(rotation) * offset);

            card.GetComponent<Transform>().position = player.position + offsetVector;
        }
    }
    */
}