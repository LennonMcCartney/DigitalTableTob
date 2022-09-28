using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnText : MonoBehaviour {
	[SerializeField] TextMeshProUGUI textMesh;

	[SerializeField] PlayManager playManager;

	private void Update() {
		textMesh.text = "Player " + playManager.GetPlayerTurn() + "'s turn";
	}
}