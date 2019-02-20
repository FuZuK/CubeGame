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
		loadScene(SceneManager.GetActiveScene().name);
	}

	public void FinishGame() {
		panelFinish.SetActive(true);
	}

	public void LoadNextLevel() {
		String currentLevel = SceneManager.GetActiveScene().name;

		for (int i = 0; i < levels.Length; i++) {
			String level = levels[i];

			if (i == levels.Length - 1) {
				loadScene("Menu");
				break;
			}

			if (level == currentLevel) {
				loadScene(levels[i + 1]);
				break;
			}
		}
	}

	private void loadScene(String level) {
		SceneManager.LoadScene(level);
	}
}
