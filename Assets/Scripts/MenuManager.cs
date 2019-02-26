using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public int currentIndex = 0;
	private GameObject[] menuItems;
	private String[] items = { "Play", "Quit" };

	void Start() {
		menuItems = GameObject.FindGameObjectsWithTag("MenuItem");
		selectMenuItem(currentIndex);
	}

	void Update () {
		if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) {
			selectNextItem();
		}

		if (Input.GetKeyDown("w") || Input.GetKeyDown("up")) {
			selectPreventItem();
		}

		if (Input.GetKeyDown("return")) {
			String itemText = items[currentIndex];

			if (itemText == "Play") {
				startGame();
			}

			if (itemText == "Quit") {
				Application.Quit();
			}
		}
	}

	void selectNextItem() {
		deselectMenuItem(currentIndex);

		if (currentIndex == items.Length - 1) {
			currentIndex = 0;
		} else {
			currentIndex++;
		}

		selectMenuItem(currentIndex);
	}

	void selectPreventItem() {
		deselectMenuItem(currentIndex);

		if (currentIndex == 0) {
			currentIndex = items.Length - 1;
		} else {
			currentIndex--;
		}

		selectMenuItem(currentIndex);
	}

	void selectMenuItem(int index) {
		String itemText = items[index];
		Text nextMenuItemText = Array.Find(menuItems, x => x.GetComponent<Text>().text.ToString() == itemText).GetComponent<Text>();

		nextMenuItemText.color = Color.red;
	}

	void deselectMenuItem(int index) {
		String itemText = items[index];
		Text nextMenuItemText = Array.Find(menuItems, x => x.GetComponent<Text>().text.ToString() == itemText).GetComponent<Text>();

		nextMenuItemText.color = Color.gray;
	}

	void startGame() {
		SceneManager.LoadScene("Level");
	}
}
