using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour {

	private TextMeshProUGUI textMesh;

	[SerializeField] private Player player;

	private void Start() {
		textMesh = GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		textMesh.text = "Player " + player.GetIndex() + "\nLives: " + player.lives;
	}
}
