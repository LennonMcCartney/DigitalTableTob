using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static List<Player> playersInGame;

    [SerializeField] private GameObject playersContainer;

    private int turnDirection = 1;
    private int turnOfPlayer = 1;

    // Happens upon the previous player selecting "End Turn"
    void NextTurn() {
        // Needs to find the next unskipped player
        int advanced = 0; // How far ahead next player is
        bool foundPlayer = false; // If we have found them yet
        while (advanced < 100 && !foundPlayer) {
            advanced++;
            int turnsToSkip = playersInGame[turnOfPlayer - 1 + advanced].turnsToSkip;
            if (turnsToSkip == 0) {
                foundPlayer = true;
            }
            else {
                turnsToSkip--;
            }
        }

        SetPlayerTurn((turnOfPlayer + turnDirection) % playersInGame.Count);
    }

    void SetPlayerTurn(int nextPlayer) {
        // Move visual assets around to the correct player

        // Player draws cards

        // Enable current player to play
        turnOfPlayer = nextPlayer;
        Debug.Log("It is now Player "+turnOfPlayer.ToString()+"'s turn");
    }

    // Start is called before the first frame update
    void Start()
    {
        playersInGame = new List<Player>();

        // Initialize players in game list; adds each player component to the list
        foreach (Player player in playersContainer.GetComponentsInChildren<Player>()) {
            if (player != null) {
                Debug.Log(player.GetComponent<Transform>().name);
                playersInGame.Add(player);
            }
            
        }

        SetPlayerTurn(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
