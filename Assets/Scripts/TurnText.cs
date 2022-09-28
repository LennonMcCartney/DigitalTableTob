using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnText : MonoBehaviour {
	TextMeshProUGUI textMesh;

	[SerializeField] PlayManager playManager;

	private void Start() {
		textMesh = GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		textMesh.text = "Player " + playManager.GetPlayerTurn() + "'s turn";
	}
}