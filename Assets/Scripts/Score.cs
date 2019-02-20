using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Transform playerTransform;
	public Text scoreText;
	private GameManager gameManager;

	void Start() {
		gameManager = FindObjectOfType<GameManager>();
	}

	void Update() {
		if (!gameManager.gameHasEnded) {
			scoreText.text = playerTransform.position.z.ToString("0");
		} else {
			scoreText.text = "You lose";
		}
	}
}
