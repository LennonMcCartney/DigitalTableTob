using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	public static List<Player> playersInGame;
	public static int playersAlive = 4;

	[SerializeField] private GameObject playersContainer;

	[SerializeField] private Pickup newCardPrefab;

	public int turnDirection = 1;
	private int turnOfPlayer = 0;

	// Happens upon the previous player selecting "End Turn"
	/*
	void NextTurn() {
		// Needs to find the next unskipped player
		int advanced = 0; // How far ahead next player is
		bool foundPlayer = false; // If we have found them yet
		while (advanced < 100 && !foundPlayer) {
			advanced = advanced + 1;
			int turnsToSkip = playersInGame[(turnOfPlayer + advanced) % playersInGame.Count].turnsToSkip;
			if (turnsToSkip == 0) {
				Debug.Log("= 0");
				foundPlayer = true;
			} else {
				Debug.Log("!= 0");
				playersInGame[(turnOfPlayer + advanced) % playersInGame.Count].turnsToSkip --;
			}
		}

		SetPlayerTurn((turnOfPlayer + turnDirection * advanced) % playersInGame.Count);
	}
	*/

	void NextTurn() {
		turnOfPlayer = (turnOfPlayer + turnDirection) % 4;
		if ( turnDirection < 0 && turnOfPlayer < 0 ) {
			turnOfPlayer = 3;
		}

		Debug.Log( playersInGame[turnOfPlayer].inGame);

		if ( playersInGame[turnOfPlayer].inGame ) {
			SetPlayerTurn(turnOfPlayer);
		} else {
			NextTurn();
		}
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

	public Player GetCurrentPlayer() {
		return playersInGame[turnOfPlayer];
	}

	private void OnMouseDown() {
		if (playersAlive > 1) {
			Pickup newCard = Instantiate(newCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			newCard.transform.parent = playersInGame[turnOfPlayer].transform;
			newCard.player = playersInGame[turnOfPlayer];
			playersInGame[turnOfPlayer].cards.Add(newCard); ;
			playersInGame[turnOfPlayer].LayoutCards();

			if (newCard.cardType == CardType.FbiLizard) {
				playersInGame[turnOfPlayer].DamagePlayer(1);

			}
			NextTurn();
		}
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