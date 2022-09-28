using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	public static List<Player> playersInGame;

	[SerializeField] private GameObject playersContainer;

	[SerializeField] private Pickup newCardPrefab;

	private int turnDirection = 1;
	private int turnOfPlayer;

	// Happens upon the previous player selecting "End Turn"
	void NextTurn() {
		// Needs to find the next unskipped player
		int advanced = 0; // How far ahead next player is
		bool foundPlayer = false; // If we have found them yet
		while (advanced < 100 && !foundPlayer) {
			advanced = advanced + 1;
			int turnsToSkip = playersInGame[(turnOfPlayer + advanced - 1) % playersInGame.Count].turnsToSkip;
			if (turnsToSkip == 0) {
				foundPlayer = true;
			} else {
				Debug.Log("Decreased");
				playersInGame[(turnOfPlayer + advanced - 1) % playersInGame.Count].turnsToSkip --;
			}
		}

		SetPlayerTurn((turnOfPlayer + turnDirection * advanced) % playersInGame.Count);
	}

	void SetPlayerTurn(int nextPlayer) {
		// Move visual assets around to the correct player

		// Player draws cards

		// Enable current player to play
		turnOfPlayer = nextPlayer;
		//Debug.Log("It is now Player " + turnOfPlayer.ToString() + "'s turn");
	}

	public int GetPlayerTurn() {
		return turnOfPlayer + 1;
	}

	private void OnMouseDown() {
		Pickup newCard = Instantiate( newCardPrefab, new Vector3(0,0,0), Quaternion.identity );
		newCard.transform.parent = playersInGame[turnOfPlayer].transform;
		playersInGame[turnOfPlayer].cards.Add( newCard ); ;
		playersInGame[turnOfPlayer].LayoutCards();

		if ( newCard.cardType == CardType.Damage ) {
			playersInGame[turnOfPlayer].lives--;
		}
		NextTurn();
	}

	void Start() {
		playersInGame = new List<Player>();
		int playerIndex = 0;
		// Initialize players in game list; adds each player component to the list
		foreach (Player player in playersContainer.GetComponentsInChildren<Player>()) {
			if (player != null) {
				//Debug.Log(player.GetComponent<Transform>().name);
				playersInGame.Add(player);
				playersInGame[playerIndex].index = playerIndex;
				playerIndex++;
			}
		}

		// Set the current turn to that of the first player
		SetPlayerTurn(0);
	}
}
