using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour {
	void OnAminationEnd() {
		FindObjectOfType<GameManager>().LoadNextLevel();
	}
}
