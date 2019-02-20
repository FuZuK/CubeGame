using UnityEngine;

public class FinishTrigger : MonoBehaviour {
	void OnTriggerEnter() {
		FindObjectOfType<GameManager>().FinishGame();
	}
}
