using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public CardType cardType;

	public Camera myCamera;

	public Player player;

	[SerializeField] PlayManager playManager;

	[SerializeField] GameObject cardGood;
	[SerializeField] GameObject cardBad;
	[SerializeField] GameObject cardChangeTurn;

	int playerIndex;

	//int FbiLizard;
	//int vpnCount;

	private void Awake() {
		int cardTypeNum = Random.Range( 0, 3 );
		switch ( cardTypeNum ) {
			case 0:
				cardType = CardType.FbiLizard;
				cardGood.SetActive( false );
				cardBad.SetActive( true );
				cardChangeTurn.SetActive( false );
				break;
			case 1:
				cardType = CardType.Vpn;
				cardGood.SetActive( true );
				cardBad.SetActive( false );
				cardChangeTurn.SetActive(false);
				break;
			case 2:
				cardType = CardType.TurnOrder;
				cardGood.SetActive( false );
				cardBad.SetActive( false );
				cardChangeTurn.SetActive( true );
				break;
			default:
				Debug.Log( "Card type num invalid" );
				break;
		}
	}

	private void Start() {
		playManager = GameObject.FindWithTag( "PlayManager" ).GetComponent<PlayManager>();
	}

	public void Look() {
		transform.LookAt( myCamera.transform.position );
	}

	private void OnMouseDown() {
		if ( player.index == playManager.GetCurrentPlayer().index ) {
			switch ( cardType ) {
				case CardType.FbiLizard:
					Debug.Log( "FBI Lizard clicked" );
					break;
				case CardType.Vpn:
					Debug.Log( "VPN clicked" );
					break;
				case CardType.TurnOrder:
					Debug.Log( "Turn Direction clicked" );
					playManager.turnDirection *= -1;
					break;
				default:
					break;
			}
		}
	}
}

public enum CardType {
	FbiLizard,
	Vpn,
	TurnOrder,
}