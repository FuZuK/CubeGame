using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject panelFinish;
	public GameObject obstaclePrefab;
	public Transform groundTransform;
	public Transform obstacleBasis;
	public Transform transformFinish;

	public bool gameHasEnded = false;
	public float gapLength = 10f;

	public void Start() {
		Debug.Log("Loaded game manager");
		GenerateObstacles();
		Debug.Log("Generated obstacles");
	}

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
		if (Persistance.Level == Persistance.MaxLevels) {
			LoadScene("Menu");
		} else {
			Persistance.Level++;
			Restart();
		}
	}

	public void LoadScene(String level) {
		SceneManager.LoadScene(level);
	}

	public void GenerateObstacles() {
		System.Random random = new System.Random();
		GameObject obstacle = null;
		float left = -2.6f;
		float right = 2.6f;

		for (int i = 1; i <= Persistance.GetObstaclesNumber(); i++) {
			Vector3 obstaclePosition = new Vector3((float) random.NextDouble() * (right - left) + left, 0f, gapLength * i);
			obstacle = Instantiate(obstaclePrefab, obstacleBasis.position + obstaclePosition, obstacleBasis.rotation) as GameObject;
		}

		if (obstacle != null) {
			float raceLength = obstacle.transform.position.z + gapLength;

			transformFinish.position += new Vector3(0f, 0f, raceLength);
		}
	}
}
