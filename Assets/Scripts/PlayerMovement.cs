﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;
	public float forwardForce = 2000f;
	public float sideawaysForce = 500f;
	private GameManager gameManager;

	void Start() {
		gameManager = FindObjectOfType<GameManager>();
	}

	void FixedUpdate () {
		if (!gameManager.gameHasEnded) {
			rb.AddForce(0, 0, forwardForce * Time.deltaTime);

			if (Input.GetKey("d") || Input.GetKey("right")) {
				rb.AddForce(sideawaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			}

			if (Input.GetKey("a") || Input.GetKey("left")) {
				rb.AddForce(-sideawaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			}

			if (rb.position.y < 0) {
				enabled = false;
				FindObjectOfType<GameManager>().EndGame();
			}
		}

		if (Input.GetKey("escape")) {
			FindObjectOfType<GameManager>().LoadScene("Menu");
		}
	}
}
