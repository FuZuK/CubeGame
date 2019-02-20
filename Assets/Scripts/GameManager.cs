using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject panelFinish;
	public bool gameHasEnded = false;
	private String[] levels = { "Level1", "Level2", "Level3" };

	public void EndGame() {
		if (!gameHasEnded) {
			gameHasEnded = true;
			Invoke("Restart", 2f);
		}
	}

	public void Restart() {
		LoadScene(SceneManager.GetActiveScene().name);
	}

	public void FinishGame() {
		panelFinish.SetActive(true);
	}

	public void LoadNextLevel() {
		String currentLevel = SceneManager.GetActiveScene().name;

		for (int i = 0; i < levels.Length; i++) {
			String level = levels[i];

			if (i == levels.Length - 1) {
				LoadScene("Menu");
				break;
			}

			if (level == currentLevel) {
				LoadScene(levels[i + 1]);
				break;
			}
		}
	}

	public void LoadScene(String level) {
		SceneManager.LoadScene(level);
	}
}
