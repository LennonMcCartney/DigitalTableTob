using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnText : MonoBehaviour {
	TextMeshProUGUI textMesh;

	[SerializeField] PlayManager playManager;

	public static bool victor = false;

	private void Start() {
		textMesh = GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		if (victor == false) {
			textMesh.text = "Player " + playManager.GetPlayerTurn() + "'s turn";
		}
		else {
			textMesh.text = "#1 Victory Royale";
		}
	}
}