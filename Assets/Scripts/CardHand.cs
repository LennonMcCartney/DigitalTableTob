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
}